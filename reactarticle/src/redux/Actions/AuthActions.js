import {API_BASE} from "../../config/env";
import axios from "axios"
import {LOGIN,LOGIN_FAIL,LOGIN_SUCCESS} from "../Actions/actionTypes"


export const login = (loginUser) => async (dispatch) =>{
    dispatch ({ type : LOGIN, payload: {loginUser} });
    try {
        const {data} = await axios.post(API_BASE+ "/Auth/login", loginUser);
        dispatch({type:LOGIN_SUCCESS, payload: data })
        localStorage.setItem('user',JSON.stringify(data))
    } catch (error) {
        dispatch({
            type : LOGIN_FAIL,
            payload : error
        })
    }
};