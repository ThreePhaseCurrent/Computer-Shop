import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from '../../services/auth.service';

import * as AOS from 'aos';
import { FormBuilder, Form, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { IAppState } from 'src/app/store/states/app.states';
import { LogIn } from 'src/app/store/actions/user.actions';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user = {username: '', password: '', remember: false};

  loginForm: FormGroup;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private _store: Store<IAppState>) {

      this.createForm();
   }
  
  isAuth: boolean;
  loginError: string;

  private inventorySubject$ = new BehaviorSubject<boolean>(this.isAuth);
  inventoryChanger$ = this.inventorySubject$.asObservable();

  ngOnInit(): void {
    // this.authService.inventoryChanger$.subscribe(sbj => {
    //   if(sbj){}
    // });

    AOS.init();
  }

  createForm() {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],
      rememberMe: ['']
    });
  }

  onSubmit(){
    // this.authService.login(this.user.username, this.user.password, this.user.remember)
    //   .subscribe(login => {
    //     this.isAuth = true;
    //     },
    //   errorMsg => {
    //     this.loginError = <any>errorMsg;
    //   });

    console.log(this.loginForm.value);
    this._store.dispatch(new LogIn(this.user));
  }

}
