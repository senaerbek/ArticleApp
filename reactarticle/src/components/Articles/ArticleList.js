import React, { useEffect } from "react";
import { Item, Grid, Segment } from "semantic-ui-react";
import { useDispatch, useSelector } from "react-redux";
import { getArticles } from "../../redux/Actions/ArticleActions";
import Navigation from "../Navigation/Navigation";

export default function ArticleList() {
  const dispatch = useDispatch();
  const articles = useSelector((state) => state.articleReducer);
  
  useEffect(() => {
    dispatch(getArticles());
  }, []);

  return (
    <div>
      <Navigation/>
      {!articles.articles ? (
        <div>asdfasd</div>
      ) : (
        <Grid columns="equal">
          <Grid.Column stretched width={12}>
            {articles.articles.map((a) => (
              <Segment>
                <Item.Group>
                  <Item>
                    <Item.Image
                      size="tiny"
                      src="https://react.semantic-ui.com/images/wireframe/image.png"
                    />

                    <Item.Content>
                      <Item.Header as="a">{a.title}</Item.Header>
                      <Item.Meta>Description</Item.Meta>
                      <Item.Description>
                        {a.articleContent.substr(0,400)}
                      </Item.Description>
                      <Item.Extra>{a.date}</Item.Extra>
                    </Item.Content>
                  </Item>
                </Item.Group>
              </Segment>
            ))}
          </Grid.Column>
        </Grid>
      )}
    </div>
  );
}
