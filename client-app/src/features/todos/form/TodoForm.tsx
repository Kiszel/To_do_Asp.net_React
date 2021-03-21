import React, { useState, useContext, useEffect } from "react";

import {
  TodoFormValues
} from "../../../app/models/Todo";
import { v4 as uuid } from "uuid";
import { observer } from "mobx-react-lite";
import TodoStore from "../../../app/api/stores/TodoStore";
import { RouteComponentProps } from "react-router-dom";

import { combineDateAndTime } from "../../../app/common/util/Util";
import {TodoFormView} from "./TodoFormView";

// const validate = combineValidators({
//   title: isRequired({ message: "The event is require title" }),
//   category: isRequired("Category"),
//   description: composeValidators(
//     isRequired("Description"),
//     hasLengthGreaterThan(4)({
//       message: "Description needs to be at least 5 characters",
//     })
//   ),
//   city: isRequired("City"),
//   venue: isRequired("Venue"),
//   date: isRequired("Date"),
//   Time: isRequired("Time"),
// });
//console.log(validate);

interface DetailParams {
  id: string;
}

const TodoForm: React.FC<RouteComponentProps<DetailParams>> = ({
  match,
  history,
}) => {
  const activityStore = useContext(TodoStore);
  const {
    submitting,
    createTodo,
    editTodo,
    loadTodo,
  } = activityStore;

  const [todo, setTodo] = useState(new TodoFormValues());
  const [loading, setLoading] = useState(false);
  useEffect(() => {
    if (match.params.id) {
      setLoading(true);
      loadTodo(match.params.id)
        .then((todo) => {
          setTodo(new TodoFormValues(todo));
        })
        .finally(() => setLoading(false));
    }
  }, [loadTodo, match.params.id]);

  const handleFinalFormSubmit = (values: any) => {
    const dateAndTime = combineDateAndTime(values.date, values.time);
    const { date, time, ...todo } = values;
    todo.date = dateAndTime;
    todo.priority=parseInt(values.priority)
    if (!todo.id) {
      let newTodo = {
        ...todo,
      };
      console.log(newTodo,"newTodo");
      createTodo(newTodo);
    } else {
      editTodo(todo);
    }
  };
  return (
    <TodoFormView history={history} todo={todo} handleFinalFormSubmit={handleFinalFormSubmit} loading={loading} submitting={submitting} />
  );
};
export default observer(TodoForm);
