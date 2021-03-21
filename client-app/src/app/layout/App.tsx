import React from "react";
import { Container } from "semantic-ui-react";
import BoardsDashboard from "../../features/boards/BoardsDashboard";
import { observer } from "mobx-react-lite";
import {
  Route,
  withRouter,
  RouteComponentProps,
  Switch,
} from "react-router-dom";
import { HomePage } from "../../features/home/HomePage";
import { ToastContainer } from "react-toastify";
import NotFound from "./NotFound";
import NavBar from "../../features/nav/NavBar";
import TodoForm from "../../features/todos/form/TodoForm";

const App: React.FC<RouteComponentProps> = ({ location }) => {
  return (
    <>
      <ToastContainer position={"bottom-right"} />
      <Route exact path="/" component={HomePage} />
      <Route
        path={"/(.+)"}
        render={() => (
          <>
            <NavBar />
            <Container style={{ marginTop: "7em" }}>
              <Switch>
                <Route exact path="/boards" component={BoardsDashboard} />
                <Route
                  key={location.key}
                  path={["/createTodo","/manage/:id"]}
                  component={TodoForm}
                />
                <Route component={NotFound} />
              </Switch>
            </Container>
          </>
        )}
      />
    </>
  );
};

export default withRouter(observer(App));
