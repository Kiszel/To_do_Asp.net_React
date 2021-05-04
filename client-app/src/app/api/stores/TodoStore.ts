import { ITodo } from "../../models/Todo";
import { observable, action, runInAction, makeObservable } from "mobx";
import { createContext } from "react";
import {Todos} from "../Agent";
import { history } from "./../../../index";
import { toast } from "react-toastify";

class TodoStore {
  @observable.ref todo: ITodo | null = null;
  @observable.ref loadingInitial: boolean = false;
  @observable.ref submitting: boolean = false;
  @observable.ref target: string = "";
  constructor() {
    makeObservable(this);
  }


  @action.bound
  loadTodo = async (id: string) => {
      this.loadingInitial = true;
      try {
      const todo = await Todos.details(parseInt(id));
        runInAction(() => {
          todo.date = new Date(todo.date);
          this.todo = todo;
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
  };

  @action.bound
  createTodo = async (todo: ITodo) => {
    this.submitting = true;
    try {
      await Todos.create(todo);
      runInAction(() => {
        this.submitting = false;
      });
      history.push(`/boards`);
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
      await Todos.update(todo);
      runInAction(() => {
        this.todo = todo;
        this.submitting = false;
      });
      history.push(`/boards`);
    } catch (error) {
      runInAction(() => {
        this.submitting = false;
      });
      toast.error("Problem submitting data");
      console.log(error.response);
    }
  };
  @action.bound
  deleteTodo = async (
    id: number
  ) => {
    this.submitting = true;
    try {
      await Todos.delete(id);
      runInAction(() => {
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
