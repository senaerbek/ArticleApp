import React, { useState, useEffect } from "react";
import {
  Button,
  Container,
  Form,
  FormField,
  Input,
  Message,
  TextArea,
} from "semantic-ui-react";
import Navigation from "../Navigation/Navigation";
import { useDispatch, useSelector } from "react-redux";
import { addArticle } from "../../redux/Actions/ArticleActions";

export default function AddArticle() {
  const dispatch = useDispatch();
  const getArticleInfo = useSelector((state) => state.addArticleReducer);
  const [article, setArticle] = useState();
  const [Loading, setLoading] = useState(false);
  const [error, setError] = useState(false);

  useEffect(() => {
    getArticleInfo.loading === true ? setLoading(true) : setLoading(false);
    getArticleInfo.error === true ? setError(true) : setError(false);
  }, [getArticleInfo]);

  const submitHandler = (event) => {
    event.preventDefault();
    dispatch(addArticle(article));
  };

  function handleChange(event) {
    const { name, value } = event.target;
    setArticle((pArticle) => ({
      ...pArticle,
      [name]: name === "articleImage" ? event.target.files[0] : value,
    }));
  }

  return (
    <div>
      <Navigation />
      <Container>
        {}
        {error == true && (
          <Message negative style={{ textAlign: "center" }}>
            Makaleniz Eklenirken Bir Hata Oluştu
          </Message>
        )}
        <Form onSubmit={submitHandler}>
          <Form.Group widths="equal">
            <FormField>
              <label>Makale Başlığı</label>
              <Input
                required
                type="text"
                name="title"
                onChange={handleChange}
              />
            </FormField>
          </Form.Group>

          <Form.Group widths="equal">
            <FormField>
              <label>Makale Resmi</label>
              <Input
                required
                type="file"
                name="articleImage"
                onChange={handleChange}
              />
            </FormField>
          </Form.Group>

          <Form.Group widths="equal">
            <FormField>
              <label>Makale</label>
              <TextArea
                required
                name="articleContent"
                placeholder="Makalenizi Yazın..."
                style={{ minHeight: 370, maxHeight: 370 }}
                onChange={handleChange}
              />
            </FormField>
          </Form.Group>
          <Button
            loading={Loading}
            color="teal"
            textAlign="center"
            fluid
            size="large"
          >
            <Button.Content visible>EKLE</Button.Content>
          </Button>
        </Form>
      </Container>
    </div>
  );
}
