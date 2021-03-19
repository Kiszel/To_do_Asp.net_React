import React from "react";
import styled from "styled-components";
import { Droppable } from "react-beautiful-dnd";
import TodoList from "../todos/TodoList";
import { IBoard } from "../../app/models/IBoard";
import {observer} from "mobx-react";

const Container = styled.div`
  margin: 8px;
  border: 1px solid lightgrey;
  background-color: white;
  border-radius: 2px;
  width: 220px;

  display: flex;
  flex-direction: column;
`;
const Title = styled.h3`
  padding: 8px;
`;
const TaskList = styled.div`
  padding: 8px;
  transition: background-color 0.2s ease;
  flex-grow: 1;
  min-height: 100px;
`;
interface IBoardComponent {
  board: IBoard;
  index:number;
}

@observer
export default class Board extends React.Component<IBoardComponent> {
  render() {
    return (
          <Container>
            <Title>
              {this.props.board.title}
            </Title>
            <Droppable  droppableId={this.props.board.id.toString()} type="board">
              {(provided, snapshot) => (
                <TaskList
                  ref={provided.innerRef}
                  {...provided.droppableProps}
                  style={{ backgroundColor: snapshot.isDraggingOver ? 'blue' : 'grey' }}
                >
                  <TodoList todos={this.props.board.todos} />
                  {provided.placeholder}
                </TaskList>
              )}
            </Droppable>
          </Container>
    );
  }
}
