import { LOGIN, LOGIN_FAIL, LOGIN_SUCCESS } from "../Actions/actionTypes";

export const authReducer = (state = {}, action) => {
  switch (action.type) {
    case LOGIN:
      return {
        loading: true,
      };
    case LOGIN_SUCCESS:
      return {
        isLogin: true,
        loading: false,
        user: action.payload,
      };
    case LOGIN_FAIL:
      return {
        isLogin: false,
        loading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};
