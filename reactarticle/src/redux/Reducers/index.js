import {combineReducers} from "redux"
import {articleReducer} from "../Reducers/ArticleReducers"
import {authReducer} from "../Reducers/AuthReducers"

const rootReducer = combineReducers({
    articleReducer,
    authReducer
})

export default rootReducer;