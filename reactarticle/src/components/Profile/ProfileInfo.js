import React from "react";
import { Container, Segment,  Item } from "semantic-ui-react";
import Navigation from "../Navigation/Navigation";
import logo from "../../Images/reactlogo.png";

export default function ProfileInfo() {
  return (
    <div>
      <Navigation />
      <Container>
            <Segment>
              <Item.Group>
                <Item>
                
                  <Item.Image
                    size="tiny"
                    src={
                      logo
                    }
                  />

                  <Item.Content>
                    <Item.Header>UserName</Item.Header>

                    <Item.Meta>bio</Item.Meta>
                    <Item.Extra>bio</Item.Extra>
                    <Item.Description>
                   bio
                    </Item.Description>
                  </Item.Content>
                </Item>
              </Item.Group>
            </Segment>
          </Container>
    </div>
  );
}
