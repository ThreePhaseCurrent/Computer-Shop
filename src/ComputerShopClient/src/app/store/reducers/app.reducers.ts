import { ActionReducerMap } from "@ngrx/store";
import { IAppState } from "../states/app.states";
import { authReducers } from '../reducers/auth.reducers';

export const appReducers: ActionReducerMap<IAppState> = {
    authState: authReducers
}