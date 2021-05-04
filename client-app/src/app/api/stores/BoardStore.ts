import { IBoard } from "../../models/IBoard";
import {
  observable,
  action,
  configure,
  runInAction,
  makeObservable,
} from "mobx";
import { createContext } from "react";
import { Boards } from "../Agent";
import { history } from "./../../../index";
import { toast } from "react-toastify";

configure({ enforceActions: "always" });

class BoardStore {
  @observable boardRegistry: Map<number, IBoard> = new Map();
  @observable.ref loadingInitial: boolean = false;
  @observable.ref submitting: boolean = false;
  @observable.ref boards: IBoard[] = [];
  constructor() {
    makeObservable(this);
  }

  @action.bound
  loadBoards = async () => {
    this.loadingInitial = true;
    try {
      const boards = await Boards.list();
      runInAction(() => {
        this.boards = boards;
        boards.forEach((board) => {
          this.boardRegistry.set(board.id, board);
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

  getBoard = (id: number) => {
    return this.boardRegistry.get(id);
  };
  @action.bound
  setBoards = (boards: IBoard[]) => {
    this.boards = boards;
  };

  @action.bound
  createBoard = async (board: IBoard) => {
    this.submitting = true;
    try {
      await Boards.create(board);
      runInAction(() => {
        this.boardRegistry.set(board.id, board);
        this.setBoards(Array.from(this.boardRegistry.values()))
        this.submitting = false;
      });
      history.push(`/board/${board.id}`);
    } catch (error) {
      runInAction(() => {
        this.submitting = false;
      });
      toast.error("Problem submitting data");
      console.log(error.response);
    }
  };
  @action.bound
  editBoard = async (board: IBoard) => {
    this.submitting = true;
    try {
      await Boards.update(board);
      runInAction(() => {
        this.boardRegistry.set(board.id, board);
        this.setBoards(Array.from(this.boardRegistry.values()))
        this.submitting = false;
      });
    } catch (error) {
      runInAction(() => {
        this.submitting = false;
      });
      toast.error("Problem submitting data");
      console.log(error.response);
    }
  };
  @action.bound
  editBoards = async (boards: IBoard[]) => {
    this.submitting = true;
    try {
      await Boards.updateBoards(boards);
      runInAction(() => {
        boards.forEach((b) => this.boardRegistry.set(b.id, b));
        this.setBoards(Array.from(this.boardRegistry.values()))
        this.submitting = false;
      });
    } catch (error) {
      runInAction(() => {
        this.submitting = false;
      });
      toast.error("Problem submitting data");
      console.log(error.response);
    }
  };

  @action.bound
  deleteTodoFromBoard = (id: number) => {
    const boards: IBoard[] = [];
    this.boards.forEach((b) => {
      const todos = b.todos.filter((t) => t.id !== id);
      const newBoard: IBoard = {
        ...b,
        todos: todos,
      };
      boards.push(newBoard);
    });
    this.setBoards(boards);
  };
}
export default createContext(new BoardStore());
