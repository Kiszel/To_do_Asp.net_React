import React from "react";
import { Form as FinalForm, Field } from "react-final-form";
import TextInput from "../../../app/common/Form/TextInput";
import { TextAreInput } from "../../../app/common/Form/TextAreInput";
import { SelectInput } from "../../../app/common/Form/SelectInput";
import { priority } from "../../../app/common/options/PriorityOptions";
import { DateInput } from "../../../app/common/Form/DateInput";
import { Segment, Form, Button, Grid } from "semantic-ui-react";
import { ITodo, ITodoFormValues } from "../../../app/models/Todo";

interface ITodoFormView {
  todo: ITodoFormValues;
  handleFinalFormSubmit: (values: any) => void;
  loading: boolean;
  submitting: boolean;
  history: any;
}

export const TodoFormView: React.FC<ITodoFormView> = (props: ITodoFormView) => {
  console.log(typeof props.todo.priority?.toString());
  const prio = `${props.todo.priority}`
  console.log(prio);
  return (
    <Grid>
      <Grid.Column width={"10"}>
        <Segment clearing>
          <FinalForm
            initialValues={props.todo}
            onSubmit={props.handleFinalFormSubmit}
            render={({ handleSubmit, invalid, pristine }) => (
              <Form onSubmit={handleSubmit} loading={props.loading}>
                <Field
                  name="title"
                  placeholder="Title"
                  value={props.todo.title}
                  component={TextInput}
                />
                <Field
                  placeholder="Description"
                  name="description"
                  value={props.todo.description}
                  component={TextAreInput}
                  rows={3}
                />
                <Field
                  placeholder="Priority"
                  name="priority"
                  value={props.todo?.priority}
                  options={priority()}
                  component={SelectInput}
                />
                <Form.Group widths={"equal"}>
                  <Field
                    placeholder="Date"
                    name="date"
                    value={props.todo.date}
                    component={DateInput}
                    date={true}
                  />
                  <Field
                    placeholder="Time"
                    name="time"
                    value={props.todo.time}
                    component={DateInput}
                    time={true}
                  />
                </Form.Group>
                <Button
                  loading={props.submitting}
                  floated="right"
                  positivie
                  type="submit"
                  content="Submit"
                  disabled={props.loading}
                />
                <Button
                  disabled={props.loading}
                  onClick={() => props.history.push("/boards")}
                  floated="right"
                  type="button"
                  content="Cancel"
                />
              </Form>
            )}
          />
        </Segment>
      </Grid.Column>
    </Grid>
  );
};
