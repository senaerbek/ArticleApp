import React from "react";
import { Container } from "semantic-ui-react";
import ArticleList from "../Articles/ArticleList";

export default function Dashboard() {

  return (
    <div>
       
      <Container>
        <ArticleList/>
      </Container>
    </div>
  );
}
