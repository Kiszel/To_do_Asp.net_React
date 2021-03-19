import { ITodo } from './ITodo';
export interface IBoard {
    id: number;
    title: string;
    todos:ITodo[];
  }