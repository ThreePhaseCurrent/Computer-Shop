import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { routes } from '../app-routing/routes';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
import { Observable, from, BehaviorSubject } from 'rxjs';
import { Login } from '../models/login';
import { HttpClient } from '@angular/common/http';
import { baseURL } from '../shared/baseurl';
import { tap, catchError } from 'rxjs/operators';
import { ProcessHttpmsgService } from './process-httpmsg.service';

export const ASSECC_TOKEN_KEY = "access_token";

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(private jwtHelper: JwtHelperService,
    private router: Router,
    private http: HttpClient,
    private httpMsgService: ProcessHttpmsgService) { }

  isAuth: boolean; 
  userName: string;

  private isAuthSubject$ = new BehaviorSubject<boolean>(this.isAuth);
  isAuthChanger$ = this.isAuthSubject$.asObservable();

  private userNameSubject$ = new BehaviorSubject<string>(this.userName);
  userNameChanger$ = this.userNameSubject$.asObservable();

  login(email: string, password: string, rememberMe: boolean): Observable<Login>{
      return this.http.post<Login>(`${baseURL}auth/login`, {UserLogin: email, UserPassword: password, RememberMe: rememberMe})
        .pipe(tap(loginData => {
          localStorage.setItem(ASSECC_TOKEN_KEY, loginData.accessToken);

          this.isAuth = true;
          this.isAuthSubject$.next(this.isAuth);

          this.userName = loginData.userName;
          this.userNameSubject$.next(this.userName);
        }))
        .pipe(catchError(this.httpMsgService.handleError));
  }

  isAuthenticated(): boolean{
    var token = localStorage.getItem(ASSECC_TOKEN_KEY);
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  logout(){
    localStorage.removeItem(ASSECC_TOKEN_KEY);
    
    this.isAuth = false;
    this.isAuthSubject$.next(this.isAuth);

    this.router.navigate(['']);
  }
}
