import React from "react";
import { DragDropContext, DropResult } from "react-beautiful-dnd";
import BoardStore from "../../app/api/stores/BoardStore";
import { IBoard } from "../../app/models/IBoard";
import { observer } from "mobx-react";
import { action } from "mobx";
import { LoadingComponent } from "../../app/layout/LoadingComponent";
import { BoardsDashboardView } from "./BoardsDashboardView";
import { ITodo } from "../../app/models/Todo";

@observer
class BoardsDashboard extends React.Component {
  static contextType = BoardStore;
  context!: React.ContextType<typeof BoardStore>;

  @action.bound
  public componentDidMount() {
    this.context.loadBoards();
  }
  private onDragEnd = (result: DropResult) => {
    const { destination, source, draggableId } = result;
    if (!destination) {
      return;
    }

    if (
      destination.droppableId === source.droppableId &&
      destination.index === source.index
    ) {
      return;
    }

    const home = this.context.boardRegistry.get(parseInt(source.droppableId));
    const foreign = this.context.boardRegistry.get(
      parseInt(destination.droppableId)
    );
    if (home === undefined || foreign === undefined) {
      return;
    }
    const todo = Array.from(home.todos).find(
      (b: ITodo) => b.id === parseInt(draggableId)
    );
    if (todo === undefined) {
      return;
    }
    if (home === foreign) {
      const todos = Array.from(home.todos);
      todos.splice(source.index, 1);
      todos.splice(destination.index, 0, todo);
      const newHome: IBoard = {
        ...home,
        todos: todos,
      };
      // const tempBoards = this.context.boards.map((board: IBoard) => {
      //   if (board.id === newHome.id) {
      //     return newHome;
      //   }
      //   return board;
      // });
      //this.context.setBoards(tempBoards);
      this.context.editBoard(newHome);
      return;
    }

    // moving from one list to another
    const homeTodos = Array.from(home.todos);
    homeTodos.splice(source.index, 1);
    const newHome: IBoard = {
      ...home,
      todos: homeTodos,
    };

    const foreignTodos = Array.from(foreign.todos);
    foreignTodos.splice(destination.index, 0, todo);
    const newForeign: IBoard = {
      ...foreign,
      todos: foreignTodos,
    };

    const tempBoards = this.context.boards.map((board: IBoard) => {
      if (board.id === newForeign.id) {
        return newForeign;
      } else if (board.id === newHome.id) {
        return newHome;
      }
      return board;
    });
    this.context.setBoards(tempBoards);
    this.context.editBoards(tempBoards);
  };

  public render() {
    if (this.context.loadingInitial || this.context.submitting)
      return <LoadingComponent content="Loading todos" />;
    return (
      <DragDropContext onDragEnd={this.onDragEnd}>
        <BoardsDashboardView boards={this.context.boards} />
      </DragDropContext>
    );
  }
}

export default BoardsDashboard;
