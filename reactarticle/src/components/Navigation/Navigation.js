import React from "react";
import { Link } from "react-router-dom";
import { Menu, Image, Container, Button } from "semantic-ui-react";
import logo from "../../Images/reactlogo.png";
export default function Navigation() {
  return (
    <div style={{ marginBottom: "100px" }}>
      <Menu inverted fixed="top">
        <Container>
          <Menu.Item>
            <Link to={"/dashboard"}>
              <Image src={logo} size="mini" />
            </Link>
          </Menu.Item>
          <Menu.Item>
            <h5>Makale</h5>
          </Menu.Item>
          <Menu.Item position="right">
            <Link to={"/addArticle"}>
              <Button inverted color="teal">
                Makale Ekle
              </Button>
            </Link>
          </Menu.Item>
        </Container>
      </Menu>
    </div>
  );
}
