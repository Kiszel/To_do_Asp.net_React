import React from "react";
import { ITodo } from "../../app/models/Todo";
import { Draggable } from "react-beautiful-dnd";
import styled from "styled-components";

import { ContextMenu, MenuItem, ContextMenuTrigger } from "react-contextmenu";
import "./TodoListItem.css";

const Container = styled.div`
  margin: 8px;
  border: 1px solid lightgrey;
  background-color: white;
  border-radius: 2px;
  width: 100%;

  display: flex;
  flex-direction: column;
`;

interface ITodoListItem {
  todo: ITodo;
  index: number;
  editTodo: (event: React.MouseEvent<HTMLElement>, data: any) =>void;
  deleteTodo:(event: React.MouseEvent<HTMLElement>, data: any) =>void;
}

export const TodoListItem: React.FC<ITodoListItem> = ({ todo, index,editTodo,deleteTodo }) => {

  return (
    // <Segment.Group>
    //   <Segment {...provided.draggableProps} ref={provided.innerRef}>
    //     <Item.Group>
    //       <Item>
    //         <Item.Content>
    //           <Item.Header as="a">{todo.title}</Item.Header>
    //         </Item.Content>
    //       </Item>
    //     </Item.Group>
    //   </Segment>
    //   <Segment>
    //     <Icon name="clock" />
    //     {todo.date.toString()} {/*{format(todo.date, "h:mm a")}*/}
    //   </Segment>
    //   <Segment clearing>
    //     <span>{todo.description}</span>
    //     <Button
    //       floated="right"
    //       content="View"
    //       color="blue"
    //       as={Link}
    //       to={`/todo/${todo.id}`}
    //     />
    //   </Segment>
    // </Segment.Group>
    <>
      <Draggable draggableId={todo.id.toString()} index={index}>
        {(provided) => (
          <Container
            {...provided.draggableProps}
            {...provided.dragHandleProps}
            ref={provided.innerRef}
          >
            <ContextMenuTrigger id={`Todo${todo.id}-context-menu`}>
              {todo.title}
            </ContextMenuTrigger>
          </Container>
        )}
      </Draggable>
      <ContextMenu id={`Todo${todo.id}-context-menu`}>
        <MenuItem  data={{ id: todo.id }} onClick={editTodo}>
          <span className="send"> Edit</span>
        </MenuItem>
        <MenuItem divider />
        <MenuItem  data={{ id: todo.id }} onClick={deleteTodo}>
          <span className="delete">Delete</span>
        </MenuItem>
      </ContextMenu>
    </>
  );
};
