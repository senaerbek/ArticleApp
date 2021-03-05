import { LOGIN } from "../Actions/actionTypes";

export const authReducer = (state = {}, action) =>{
    switch(action.type){
        case LOGIN:
            return{
                user : action.payload
            }
        default:
            return state
    }
};