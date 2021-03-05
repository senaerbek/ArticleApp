import { GET_ARTICLES } from "../Actions/actionTypes";

export const articleReducer = (state = {}, action) =>{
    switch(action.type){
        case GET_ARTICLES:
            return{
                articles : action.payload
            }
        default:
            return state
    }
};