import React, { Fragment, useContext } from "react";
import { Item } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { TodoListItem } from "./TodoListItem";
import { ITodo } from "../../app/models/Todo";
import TodoStore from "../../app/api/stores/TodoStore";
import { history } from "../../index";
import BoardStore from "../../app/api/stores/BoardStore";

interface ITodoList {
  todos: ITodo[];
}
const TodoList: React.FC<ITodoList> = (props) => {
  const todoStore = useContext(TodoStore);
  const boardStore = useContext(BoardStore);
  const editTodo = (event: React.MouseEvent<HTMLElement>, data: any) => {
    history.push(`/manage/${data.id}`);
  };
  const deleteTodo = (event: React.MouseEvent<HTMLElement>, data: any) => {
    todoStore.deleteTodo(data.id);
    boardStore.deleteTodoFromBoard(data.id)
  };
  return (
    <Fragment>
      <Item.Group divided>
        {props.todos.map((todo: ITodo, index: number) => (
          <TodoListItem
            editTodo={editTodo}
            deleteTodo={deleteTodo}
            index={index}
            key={todo.id}
            todo={todo}
          />
        ))}
      </Item.Group>
    </Fragment>
  );
};

export default observer(TodoList);
