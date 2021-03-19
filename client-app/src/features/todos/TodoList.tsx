import React, {  Fragment } from "react";
import { Item } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { TodoListItem } from "./TodoListItem";
import { ITodo } from "../../app/models/ITodo";


interface ITodoList{
  todos:ITodo[]
}
const TodoList: React.FC<ITodoList> = (props) => {

  return (
    <Fragment>
      <Item.Group divided>
        {props.todos.map((todo: ITodo,index:number) => (
          <TodoListItem index={index} key={todo.id} todo={todo} />
        ))} 
      </Item.Group>
    </Fragment>
  );
};

export default observer(TodoList);
