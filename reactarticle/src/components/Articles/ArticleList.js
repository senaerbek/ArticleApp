import React, { useEffect } from "react";
import { Item, Grid, Segment } from "semantic-ui-react";
import { useDispatch, useSelector } from "react-redux";
import { getArticles } from "../../redux/Actions/ArticleActions";
import Navigation from "../Navigation/Navigation";
import { Link } from "react-router-dom";

export default function ArticleList() {
  const dispatch = useDispatch();
  const articles = useSelector((state) => state.articleReducer);

  useEffect(() => {
    dispatch(getArticles());
  }, []);

  return (
    <div>
      <Navigation />
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
                      src={"data:image/png;base64," + a.articleImage}
                    />

                    <Item.Content>
                      <Link to={"/details/" + a.articleId}>
                        <Item.Header as="a">
                          <h2>
                             {a.title} -- {a.articleId}
                          </h2>
                         
                        </Item.Header>
                      </Link>
                      <Link to={"profile/" + a.userId}><Item.Meta>{a.userName}</Item.Meta>
                      </Link>
                      
                      <Item.Description>
                        {a.articleContent.substr(0, 400)}
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
