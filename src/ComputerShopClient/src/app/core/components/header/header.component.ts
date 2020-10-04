import { Component, OnInit, Renderer2, AfterViewInit } from '@angular/core';
import {ACCESS_USERNAME_KEY, ACCESS_TOKEN_KEY, AuthService} from '../../services/auth.service';
import { DestroyService } from '../../services/destroy.service';

import * as AOS from 'aos';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../../../shared/components/login/login.component';
import {User} from "../../../shared/models/user";
import {Store} from "@ngrx/store";
import {IAppState} from "../../store/states/app.states";
import {selectUser} from "../../store/selectors/auth.selectors";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  userName: string;
  user = new User();

  constructor(
    private authService: AuthService,
    private destroy$: DestroyService,
    public dialog: MatDialog,
    private _store: Store<IAppState>) {

  this.initScripts();
    AOS.init();

    if(!this.isLoggedIn) {
      this._store.select(selectUser).subscribe(x => this.user = x);
    } else {
      this.user.accessToken = localStorage.getItem(ACCESS_TOKEN_KEY);
      this.user.userName = localStorage.getItem(ACCESS_USERNAME_KEY);
    }
  }

  public get isLoggedIn(): boolean {
    return this.authService.isAuthenticated();
  }

  logout(){
    this.authService.logout();
  }

  openLoginForm() {
    let dialogResult = this.dialog.open(LoginComponent, {backdropClass: 'login-form-overlay'});
  }

  ngOnInit(): void {
    this.authService.userNameChanger$.pipe()
    .subscribe(user =>{
      this.userName = <string>user;
    });
  }

  initScripts(){
    let testScript = document.createElement("script");
    testScript.setAttribute("src", "../../../assets/js/header/test.js");
    document.body.appendChild(testScript);
  }

}
