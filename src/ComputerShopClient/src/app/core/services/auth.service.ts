import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { routes } from '../../app-routing/routes';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
import { Observable, from, BehaviorSubject } from 'rxjs';
import { Login } from '../../shared/models/login';
import { HttpClient } from '@angular/common/http';
import { baseURL } from '../../shared/models/baseUrl';
import { tap, catchError } from 'rxjs/operators';
import { ProcessHttpmsgService } from './process-httpmsg.service';
import { Register } from '../../shared/models/register';

export const ACCESS_TOKEN_KEY = "access_token";
export const ACCESS_USERNAME_KEY = "access_username";

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

  login(email: string, password: string, rememberMe: boolean): Observable<Login> {
      console.log(`${email} ${rememberMe} ${password}`);
      return this.http.post<Login>(`${baseURL}auth/login`,
        {
          UserLogin: email,
          UserPassword: password,
          RememberMe: rememberMe
        })
        .pipe(tap(loginData => {
          localStorage.setItem(ACCESS_TOKEN_KEY, loginData.accessToken);
          localStorage.setItem(ACCESS_USERNAME_KEY, loginData.email);

          this.isAuth = true;
          this.isAuthSubject$.next(this.isAuth);

          this.userName = loginData.email;
          this.userNameSubject$.next(this.userName);
        }));
  }

  isAuthenticated(): boolean {
    var token = localStorage.getItem(ACCESS_TOKEN_KEY);
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  checkUserName(userName: string): Observable<boolean>{
    if(userName == '') return new Observable;

    return this.http.get<boolean>(`${baseURL}auth/username-check/` + userName);
  }

  register(data: Register): Observable<any> {
    console.log(data);
    return this.http.post(`${baseURL}auth/register`, {
      FirstName: data.firstName,
      LastName: data.lastName,
      UserName: data.userName,
      Email: data.email,
      Password: data.password,
      Phone: data.phoneNumber.e164Number
    })
    .pipe(catchError(this.httpMsgService.handleError));
  }

  logout(){
    localStorage.removeItem(ACCESS_TOKEN_KEY);

    this.isAuth = false;
    this.isAuthSubject$.next(this.isAuth);

    this.router.navigate(['']);
  }
}
