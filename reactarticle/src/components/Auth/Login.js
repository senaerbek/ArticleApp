import React, { useState, useEffect } from "react";
import {
  Button,
  Container,
  Form,
  Header,
  Icon,
  Image,
  Message,
  Segment,
} from "semantic-ui-react";
import { useDispatch, useSelector } from "react-redux";
import { login } from "../../redux/Actions/AuthActions";
import { useHistory } from "react-router-dom";
import logo from "../../Images/reactlogo.png"

export default function Login(props) {
  const dispatch = useDispatch();
  let history = useHistory();
  const [user, setuser] = useState({});
  const uInfo = useSelector((state) => state.authReducer);
  const isLogin = uInfo.isLogin;
  console.log(uInfo);
  
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

  useEffect(() => {
    if (isLogin) {
      setTimeout(function () {
        history.push("/dashboard");
      }, 1000);
    }
  }, [isLogin]);

  return (
    <div>
      <Container text>
        <Segment>
          <Header as="h2" color="teal" textAlign="center">
            <Image src={logo} /> Log-in to your account
          </Header>
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

            {isLogin === false ? (
              <div>
                <Message style={{ marginBottom: "10px" }} negative>
                  <Message.Header>Hata</Message.Header>
                  <p>Kullanıcı adı veya şifreniz yanlış.</p>
                </Message>
              </div>
            ) : (
              <div></div>
            )}
            <Button  textAlign='center' fluid size="large" color="teal" animated>
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
