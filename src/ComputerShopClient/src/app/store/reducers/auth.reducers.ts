import { initialAuthState } from "../states/auth.states";
import { IAuthState } from "../states/auth.states";
import  {UserActions} from "../actions/user.actions";

export const authReducers = (
    state = initialAuthState,
    action: UserActions): IAuthState => {
        switch(action.type){

            default:
                return state;
        }
}