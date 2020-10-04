import { ActionReducerMap } from "@ngrx/store";
import { IAppState } from "../states/app.states";
import { authReducers } from './auth.reducers';

export const appReducers: ActionReducerMap<IAppState> = {
    authState: authReducers
}
