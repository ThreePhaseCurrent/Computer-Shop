import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user = {username: '', password: '', remember: false};

  constructor(public dialogRef: MatDialogRef<LoginComponent>,
    private authService: AuthService) {
   }
  
  isAuth: boolean;
  loginError: string;

  private inventorySubject$ = new BehaviorSubject<boolean>(this.isAuth);
  inventoryChanger$ = this.inventorySubject$.asObservable();

  ngOnInit(): void {
    // this.authService.inventoryChanger$.subscribe(sbj => {
    //   if(sbj){}
    // });
  }

  onSubmit(){
    this.authService.login(this.user.username, this.user.password, this.user.remember)
      .subscribe(login => {
        this.isAuth = true;
        
        this.dialogRef.close();
      },
      errorMsg => {
        this.loginError = <any>errorMsg;
      });
  }

}
