import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { baseURL } from '../../shared/models/baseUrl';
import {ACCESS_TOKEN_KEY} from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  getData(): Observable<String>{
    return this.http.get<String>(baseURL + 'home/index', {responseType:'text' as 'json'});
  }
}
