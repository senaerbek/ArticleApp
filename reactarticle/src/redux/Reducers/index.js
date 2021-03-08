import {combineReducers} from "redux"
import {articleReducer, articleDetailReducer} from "../Reducers/ArticleReducers"
import {authReducer} from "../Reducers/AuthReducers"

const rootReducer = combineReducers({
    articleReducer,
    authReducer,
    articleDetailReducer
})

export default rootReducer;