import { Priority } from "./Priorty";

export interface ITodo {
  id: number;
  title: string;
  description: string;
  date: Date;
  priority: Priority | undefined;
}
export interface ITodoFormValues extends Partial<ITodo> {
  time?: Date;
}

export class TodoFormValues implements ITodoFormValues {
  id?: number = undefined;
  title: string = "";
  description: string = "";
  date?: Date = undefined;
  time?: Date = undefined;
  priority: Priority| undefined = undefined;

  constructor(init?: ITodoFormValues) {
    if (init && init.date) {
      init.time = init.date;
    }
    Object.assign(this, init);
  }
}
