import { initialAuthState } from "../states/auth.states";
import { IAuthState } from "../states/auth.states";
import {AuthActionTypes, UserActions} from "../actions/user.actions";

export const authReducers = (
  state = initialAuthState,
  action: UserActions): IAuthState => {
      switch(action.type){

        case AuthActionTypes.LOGIN:
          return {
            ...state,
            hasError: false,
            errorMessage: null,
            isAuthenticated: false,
            isLoading: true
          };

        case AuthActionTypes.LOGIN_SUCCESS:
          return {
            ...state,
            hasError: false,
            errorMessage: null,
            isAuthenticated: true,
            isLoading: false
          }

        case AuthActionTypes.LOGIN_FAIL:
          return {
            ...state,
            hasError: true,
            errorMessage: action.payload,
            isAuthenticated: false,
            isLoading: false
          }

        default:
              return state;
      }
}
