import React from "react";
import { Menu, Container, Button } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { NavLink } from "react-router-dom";

const NavBar: React.FC = () => {
  return (
    <Menu fixed="top" inverted>
      <Container>
        <Menu.Item header exact as={NavLink} to="/">
          <span>Todos</span>
        </Menu.Item>
        <Menu.Item name="Boards" as={NavLink} to="/boards" />
        <Menu.Item>
          <Button
            positive
            content="Create Todo"
            as={NavLink}
            to="/createTodo"
          />
        </Menu.Item>
      </Container>
    </Menu>
  );
};

export default observer(NavBar);
