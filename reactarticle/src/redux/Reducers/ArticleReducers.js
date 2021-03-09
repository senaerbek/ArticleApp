import { ADD_ARTICLE_FAIL, ADD_ARTICLE_REQUEST, ADD_ARTICLE_SUCCESS, GET_ARTICLES ,GET_ARTICLE_DETAIL} from "../Actions/actionTypes";

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

export const addArticleReducer =(state={}, action)=>{
    switch(action.type){
        case ADD_ARTICLE_REQUEST:
            return {loading : true};
        case ADD_ARTICLE_SUCCESS:
            return{loading: false, addedArticle : action.payload};
        case ADD_ARTICLE_FAIL:
            return{loading : false , error : action.payload};
        default: 
            return state;
    }
}