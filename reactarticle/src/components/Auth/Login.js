import React, { useState } from "react";
import { Button, Container, Form, Icon, Segment } from "semantic-ui-react";
import { useDispatch, useSelector } from "react-redux";
import { login } from "../../redux/Actions/AuthActions";
import { useHistory } from "react-router-dom";

export default function Login() {
  const dispatch = useDispatch();
  let history = useHistory();
  const [user, setuser] = useState({});

  function handleChange(event) {
    const { name, value } = event.target;
    setuser((pUser) => ({
      ...pUser,
      [name]: name === "id" ? parseInt(value, 10) : value,
    }));
  }

  const handleSave = (event) => {
    event.preventDefault();
    dispatch(login(user));
  };

  return (
    <div>
      <Container text>
        <Segment>
          <Form onSubmit={handleSave} error>
            <Form.Input
              name="Email"
              label="Email"
              placeholder="joe@schmoe.com"
              onChange={handleChange}
            />
            <Form.Input
              name="Password"
              type="Password"
              label="Şifre"
              placeholder="**************"
              onChange={handleChange}
            />
            <Button color="teal" animated>
              <Button.Content visible>Giriş</Button.Content>
              <Button.Content hidden>
                <Icon name="arrow right" />
              </Button.Content>
            </Button>
          </Form>
        </Segment>
      </Container>
    </div>
  );
}
