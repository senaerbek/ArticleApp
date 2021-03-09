import {combineReducers} from "redux"
import {articleReducer, articleDetailReducer,addArticleReducer} from "../Reducers/ArticleReducers"
import {authReducer} from "../Reducers/AuthReducers"

const rootReducer = combineReducers({
    articleReducer,
    authReducer,
    articleDetailReducer,
    addArticleReducer
})

export default rootReducer;