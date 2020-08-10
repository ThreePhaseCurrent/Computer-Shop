import { Injectable } from "@angular/core";
import { AuthService } from 'src/app/services/auth.service';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { AuthActionTypes, LogIn, LogInSuccess, LogInFiled } from '../actions/user.actions';
import { map, switchMap, catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable()
export class AuthEffects {
    constructor(
        private actions: Actions,
        private authService: AuthService
    ) {}


    @Effect()
    logIn$: Observable<any> = this.actions.pipe(
        ofType<LogIn>(AuthActionTypes.LOGIN),
        switchMap((action) => {
            return this.authService.login(
                action.user.email, 
                action.user.password,
                action.user.rememberMe)
            .pipe(
                map(result => new LogInSuccess(result)),
                catchError(error => of(new LogInFiled(error)))
            );
        })
    )
}