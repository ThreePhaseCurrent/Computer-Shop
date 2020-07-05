import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { routes } from '../app-routing/routes';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
import { Observable, from, BehaviorSubject } from 'rxjs';
import { Token } from '../models/token';
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

  isAuth; 

  private inventorySubject$ = new BehaviorSubject<boolean>(this.isAuth);
  inventoryChanger$ = this.inventorySubject$.asObservable();

  login(email: string, password: string, rememberMe: boolean): Observable<Token>{
      return this.http.post<Token>(`${baseURL}auth/login`, {UserLogin: email, UserPassword: password, RememberMe: rememberMe})
        .pipe(tap(token => {
          localStorage.setItem(ASSECC_TOKEN_KEY, token.access_token);

          this.isAuth = true;
          this.inventorySubject$.next(this.isAuth);
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
    this.inventorySubject$.next(this.isAuth);

    this.router.navigate(['']);
  }
}
