import { API_BASE, headers } from "../../config/env";
import axios from "axios";
import {
  GET_ARTICLES,
  GET_ARTICLE_DETAIL,
  ADD_ARTICLE_REQUEST,
  ADD_ARTICLE_SUCCESS,
  ADD_ARTICLE_FAIL,
} from "../Actions/actionTypes";

export const getArticles = () => async (dispatch) => {
  const response = await axios(API_BASE + "/Articles", { headers: headers });
  dispatch({
    type: GET_ARTICLES,
    payload: response.data,
  });
};

export const getArticleDetail = (articleId) => async (dispatch) => {
  const response = await axios(API_BASE + "/Articles/" + articleId, {
    headers: headers,
  });
  dispatch({
    type: GET_ARTICLE_DETAIL,
    payload: response.data,
  });
};



export const addArticle = (article) => async (dispatch) => {
  dispatch({ type: ADD_ARTICLE_REQUEST, payload: article });
  try {
    const data = new FormData();
    data.append("title", article.title);
    data.append("articleContent", article.articleContent);
    data.append("articleImage", article.articleImage);
    const  response  = await axios.post(API_BASE + "/Articles/", data, {
      headers: headers,
    });
    console.log(response.data)
    dispatch({ type: ADD_ARTICLE_SUCCESS, payload: response });
  } catch (error) {
    dispatch({
      type: ADD_ARTICLE_FAIL,
      payload: true
    });
  }
};
