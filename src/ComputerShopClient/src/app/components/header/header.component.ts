import { Component, OnInit, Renderer2, AfterViewInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { DestroyService } from '../../services/destroy.service';

import * as AOS from 'aos';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  userName: string;

  constructor(private authService: AuthService,
    private destroy$: DestroyService) { 

      var testScript = document.createElement("script");
      testScript.setAttribute("id", "testScript");
      testScript.setAttribute("src", "../../../assets/js/test.js");
      document.body.appendChild(testScript);
    }

  public get isLoggedIn(): boolean{
    return this.authService.isAuthenticated();
  }

  logout(){
    this.authService.logout();
  }

  ngOnInit(): void {
    this.authService.userNameChanger$.pipe()
    .subscribe(user =>{
      this.userName = <string>user;
    });


    AOS.init();
  }

}
