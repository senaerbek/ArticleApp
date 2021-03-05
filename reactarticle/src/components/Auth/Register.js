import React from "react";
import {
  Button,
  Container,
  Form,
  Icon,
  Segment,
} from "semantic-ui-react";

export default function Register() {
    return (
        <div>
        <Container text>
          <Segment>
            <Form error>
            <Form.Input label="Kullanıcı Adı" placeholder="joe" />
              <Form.Input label="Email" placeholder="joe@schmoe.com" />
              <Form.Input
                type="password"
                label="Şifre"
                placeholder="**************"
              />
              <Button color="teal" animated>
                <Button.Content visible>Kayıt</Button.Content>
                <Button.Content hidden>
                  <Icon name="arrow right" />
                </Button.Content>
              </Button>
            </Form>
          </Segment>
  
        </Container>
      </div>
    )
}
