import { Priority } from "./Priorty";

export interface ITodo {
    id: string;
    title: string;
    description: string;
    date: Date;
    priority:Priority;
  }
