import { Action } from '@ngrx/store';
import { User } from 'src/app/models/user';

export enum AuthActionTypes {
    LOGIN = '[Auth] Login',
    LOGIN_SUCCESS = '[Auth] Login Success',

    LOGIN_FAIL = '[Auth] Login Fail'
}

export class LogIn implements Action {
    readonly type = AuthActionTypes.LOGIN;
    constructor(public user: User) {}
}

export class LogInSuccess implements Action {
    readonly type = AuthActionTypes.LOGIN_SUCCESS;
    constructor(public payload: any) {}
}

export class LogInFiled implements Action {
    readonly type = AuthActionTypes.LOGIN_FAIL;
    constructor(public payload: any) {}
}


export type UserActions =
    | LogIn 
    | LogInSuccess
    | LogInFiled;