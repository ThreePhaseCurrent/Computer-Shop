import { ActionReducerMap } from "@ngrx/store";
import { fromEventPattern } from 'rxjs';
import { IAppState } from "../states/app.states";
import { authReducers } from './auth.reducers';
import { productReducers } from './product.reducers';

export const appReducers: ActionReducerMap<IAppState> = {
    authState: authReducers,
    productState: productReducers
}
