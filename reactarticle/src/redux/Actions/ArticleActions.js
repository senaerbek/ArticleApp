import {API_BASE ,headers} from "../../config/env";
import axios from "axios"
import {GET_ARTICLES,GET_ARTICLE_DETAIL} from "../Actions/actionTypes"



export const getArticles = () => async (dispatch) =>{
    const response = await axios(API_BASE+ "/Articles", {headers : headers});
    dispatch({
        type : GET_ARTICLES,
        payload : response.data
    });
};

export const getArticleDetail = (articleId) => async (dispatch) =>{
    const response = await axios(API_BASE+ "/Articles/" + articleId, {headers : headers});
    dispatch({
        type : GET_ARTICLE_DETAIL,
        payload : response.data
    });
};