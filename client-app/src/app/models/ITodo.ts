import { Priority } from "./Priorty";

export interface ITodo {
    id: number;
    Board_Id: number;
    title: string;
    description: string;
    date: Date;
    priority:Priority;
  }
