import {API_BASE} from "../../config/env";
import axios from "axios"
import {LOGIN} from "../Actions/actionTypes"


export const login = (loginUser) => async (dispatch) =>{
    var data = false
    const response = await axios.post(API_BASE+ "/Auth/login" , loginUser)
    
    // payload düzenlenecek 

    dispatch({
        type : LOGIN,
        payload : data
    });
};