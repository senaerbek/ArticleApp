import React, { useEffect } from "react";
import { getArticleDetail } from "../../redux/Actions/ArticleActions";
import { useDispatch, useSelector } from "react-redux";
import { Container, Item, Segment } from "semantic-ui-react";
import Navigation from "../Navigation/Navigation";


export default function ArticleDetails(props) {
  const dispatch = useDispatch();
  const articleId = props.match.params.id;
  const article = useSelector((state) => state.articleDetailReducer);
  console.log(articleId);
  useEffect(() => {
    dispatch(getArticleDetail(articleId));
  }, []);
  return (
    <div>
      {!article.articles ? (
        <div>asdasd</div>
      ) : (
        <div>
          <Navigation />
          <Container>
            <Segment>
              <Item.Group>
                <Item>
                  {console.log(article.articles)}
                  <Item.Image
                    size="tiny"
                    src={
                      "data:image/png;base64," + article.articles.articleImage
                    }
                  />

                  <Item.Content>
                    <Item.Header>{article.articles.title}</Item.Header>

                    <Item.Meta>{article.articles.userName}</Item.Meta>
                    <Item.Extra>{article.articles.date}</Item.Extra>
                    <Item.Description>
                      {article.articles.articleContent}
                    </Item.Description>
                  </Item.Content>
                </Item>
              </Item.Group>
            </Segment>
          </Container>
        </div>
      )}
    </div>
  );
}
