import { Container, Segment, Header, Button } from "semantic-ui-react";
import { Link } from "react-router-dom";

export const HomePage = () => {
  return (
    <Segment inverted textAlign="center" vertical className="masthead">
      <Container text>
        <Header as="h1" inverted>
          Todos
        </Header>
        <Header as="h2" inverted content="Welcome to Todos" />
        <Button as={Link} to="/boards" size="huge" inverted>
          Take me to the todos!
        </Button>
      </Container>
    </Segment>
  );
};
