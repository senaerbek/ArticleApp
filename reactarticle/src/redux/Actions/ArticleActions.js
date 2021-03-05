import {API_BASE} from "../../config/env";
import axios from "axios"
import {GET_ARTICLES} from "../Actions/actionTypes"

export const getArticles = () => async (dispatch) =>{
    const response = await axios(API_BASE+ "/Articles");
    dispatch({
        type : GET_ARTICLES,
        payload : response.data
    });
};