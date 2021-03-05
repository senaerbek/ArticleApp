import React from "react";
import { Button, Container, Form, FormField, Input, TextArea } from "semantic-ui-react";
import Navigation from "../Navigation/Navigation";

export default function AddArticle() {
  const submitHandler = ()=>{
    console.log("eklendi");
  }
  return (
    <div>
      <Navigation/>
      <Container>
        <Form onSubmit={submitHandler}>
          <Form.Group widths="equal">
            <Form.Field
              id="form-input-control-first-name"
              control={Input}
              label="Başlık"
              placeholder="Makale Başlığınızı Yazın..."
            />
          </Form.Group>
       <FormField>
           <label>Makale</label>
             <TextArea placeholder='Makalenizi Yazın...' style={{ minHeight: 450, maxHeight : 450  }} />
       </FormField>
         
          <Button floated="right" color="grey">İptal</Button>
          <Button floated="right" color="green">Ekle</Button>
          
        </Form>
      </Container>
    </div>
  );
}
