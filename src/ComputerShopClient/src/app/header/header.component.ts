import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component';
import { map, takeUntil, first } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';
import { DestroyService } from '../services/destroy.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  userName: string;

  constructor(private authService: AuthService,
    private destroy$: DestroyService) { }

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
  }

}
