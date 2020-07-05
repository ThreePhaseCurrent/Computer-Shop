import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component';
import { map } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(public dialog: MatDialog,
    private authService: AuthService) { }

  public get isLoggedIn(): boolean{
    return this.authService.isAuthenticated();
  }

  logout(){
    this.authService.logout();
  }

  ngOnInit(): void {
  }

  openLoginForm(){
    this.dialog.open(LoginComponent, {width: '500px', height: '450px'});
  }

}
