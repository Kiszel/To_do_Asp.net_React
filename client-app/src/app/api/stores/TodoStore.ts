import { ITodo } from "./../../models/ITodo";
import { observable, action, computed, configure, runInAction } from "mobx";
import { createContext, SyntheticEvent } from "react";
import agent from "../Agent";
import { history } from "./../../../index";
import { toast } from "react-toastify";

configure({ enforceActions: "always" });

class TodoStore {
  @observable todoRegistry = new Map();
  @observable.ref todo: ITodo | null = null;
  @observable.ref loadingInitial: boolean = false;
  @observable.ref submitting: boolean = false;
  @observable.ref target: string = "";

  @computed get todoByDate() {
    return this.groupTodosDate(Array.from(this.todoRegistry.values()));
  }

  groupTodosDate(todos: ITodo[]) {
    const sortedTodos = todos.sort(
      (a, b) => a.date.getTime() - b.date.getTime()
    );
    return Object.entries(
      sortedTodos.reduce((todos, todo) => {
        const date = todo.date.toISOString();
        todos[date] = todos[date] ? [...todos[date], todo] : [todo];
        return todos;
      }, {} as { [key: string]: ITodo[] })
    );
  }

  @action.bound loadTodos = async () => {
    this.loadingInitial = true;
    try {
      const todos = await agent.Todos.list();
      runInAction(() => {
        todos.forEach((todo) => {
          todo.date = new Date(todo.date);
          this.todoRegistry.set(todo.id, todo);
        });
        this.loadingInitial = false;
      });
    } catch (error) {
      console.log(error);
      runInAction(() => {
        this.loadingInitial = false;
      });
    }
  };
  @action.bound loadTodo = async (id: string) => {
    let todo = this.getTodo(id);
    if (todo) {
      this.todo = todo;
      return todo;
    } else {
      this.loadingInitial = true;
      try {
        todo = await agent.Todos.details(id);
        runInAction(() => {
          todo.date = new Date(todo.date);
          this.todo = todo;
          this.todoRegistry.set(todo.id, todo);
          this.loadingInitial = false;
        });
        return todo;
      } catch (error) {
        console.log(error);
        runInAction(() => {
          this.loadingInitial = false;
        });
        throw error;
      }
    }
  };

  getTodo = (id: string) => {
    return this.todoRegistry.get(id);
  };
  @action clearTodo = () => {
    this.todo = null;
  };

  @action.bound
  createTodo = async (todo: ITodo) => {
    this.submitting = true;
    try {
      await agent.Todos.create(todo);
      runInAction(() => {
        this.todoRegistry.set(todo.id, todo);
        this.submitting = false;
      });
      history.push(`/todo/${todo.id}`);
    } catch (error) {
      runInAction(() => {
        this.submitting = false;
      });
      toast.error("Problem submitting data");
      console.log(error.response);
    }
  };
  @action.bound
  editTodo = async (todo: ITodo) => {
    this.submitting = true;
    try {
      await agent.Todos.update(todo);
      runInAction(() => {
        this.todoRegistry.set(todo.id, todo);
        this.todo = todo;
        this.submitting = false;
      });
      history.push(`/todo/${todo.id}`);
    } catch (error) {
      runInAction(() => {
        this.submitting = false;
      });
      toast.error("Problem submitting data");
      console.log(error.response);
    }
  };
  @action.bound
  deleteTodo = async (event: SyntheticEvent<HTMLButtonElement>, id: string) => {
    this.submitting = true;
    this.target = event.currentTarget.name;
    try {
      await agent.Todos.delete(id);
      runInAction(() => {
        this.todoRegistry.delete(id);
        this.submitting = false;
        this.target = "";
      });
    } catch (error) {
      runInAction(() => {
        this.submitting = false;
        this.target = "";
      });
      console.log(error);
    }
  };
}

export default createContext(new TodoStore());
