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

const App: React.FC<RouteComponentProps> = ({ location }) => {
  return (
    <>
      <ToastContainer position={"bottom-right"} />
      <Route exact path="/" component={HomePage} />
      <Route
        path={"/(.+)"}
        render={() => (
          <>
            <Container style={{ marginTop: "7em" }}>
              <Switch>
                <Route exact path="/boards" component={BoardsDashboard} />
              </Switch>
            </Container>
          </>
        )}
      />
    </>
  );
};

export default withRouter(observer(App));
