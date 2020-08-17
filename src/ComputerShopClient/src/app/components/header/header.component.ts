import { Component, OnInit, Renderer2, AfterViewInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { DestroyService } from '../../services/destroy.service';

import * as AOS from 'aos';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  userName: string;

  constructor(private authService: AuthService,
    private destroy$: DestroyService,
    public dialog: MatDialog) { 

      this.initScripts();
      AOS.init();
    }

  public get isLoggedIn(): boolean{
    return this.authService.isAuthenticated();
  }

  logout(){
    this.authService.logout();
  }

  openLoginForm() {
    var dialogResult = this.dialog.open(LoginComponent, {backdropClass: 'login-form-overlay'});
  }

  ngOnInit(): void {
    this.authService.userNameChanger$.pipe()
    .subscribe(user =>{
      this.userName = <string>user;
    });
  }

  initScripts(){
    var testScript = document.createElement("script");
    testScript.setAttribute("src", "../../../assets/js/test.js");
    document.body.appendChild(testScript);
  }

}
