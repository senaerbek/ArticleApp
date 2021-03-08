import { GET_ARTICLES ,GET_ARTICLE_DETAIL} from "../Actions/actionTypes";

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

export const articleDetailReducer = (state = {}, action) =>{
    switch(action.type){
        case GET_ARTICLE_DETAIL:
            return{
                articles : action.payload
            }
        default:
            return state
    }
};