import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { routes } from '../app-routing/routes';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
import { Observable, from } from 'rxjs';
import { Token } from '../models/token';
import { HttpClient } from '@angular/common/http';
import { baseURL } from '../shared/baseurl';
import { tap } from 'rxjs/operators';

export const ASSECC_TOKEN_KEY = "token";

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(private jwtHelper: JwtHelperService,
    private router: Router,
    private http: HttpClient) { }

  login(email: string, password: string, rememberMe: boolean): Observable<Token>{
      return this.http.post<Token>(`${baseURL}auth/login`, {email, password, rememberMe})
        .pipe(tap(token => {
          localStorage.setItem(ASSECC_TOKEN_KEY, token.access_token)
        }))
  }

  isAuthenticated(): boolean{
    var token = localStorage.getItem(ASSECC_TOKEN_KEY);
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  logout(){
    localStorage.removeItem(ASSECC_TOKEN_KEY);
    this.router.navigate(['']);
  }
}
