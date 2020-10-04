import * as auth from './auth.states';
import {IProductState} from "./product.states";

export interface IAppState {
  authState: auth.IAuthState,
  productState: IProductState
}
