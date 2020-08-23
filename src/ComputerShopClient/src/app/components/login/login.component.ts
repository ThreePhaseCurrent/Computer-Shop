import { Component, OnInit } from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';
import { AuthService } from '../../services/auth.service';

import * as AOS from 'aos';
import { FormBuilder, Form, FormGroup, Validators } from '@angular/forms';
import {Action, select, Store} from '@ngrx/store';
import { IAppState } from 'src/app/store/states/app.states';
import {AuthActionTypes, LogIn} from 'src/app/store/actions/user.actions';
import {UserLogin} from "../../models/UserLogin";
import {MatDialogRef} from "@angular/material/dialog";
import {getLoading, getLoggedIn, selectAuth, selectError} from "../../store/selectors/auth.selectors";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user: UserLogin;
  loginForm: FormGroup;

  completeAuth$;
  hasError$;
  isLoading$;

constructor(
  private authService: AuthService,
  private fb: FormBuilder,
  private _store: Store<IAppState>,
  public dialogRef: MatDialogRef<LoginComponent>) {

    this.createForm();

    this.completeAuth$ = this._store.pipe(select(getLoggedIn));
    this.hasError$ = this._store.pipe(select(selectError));
    this.isLoading$ = this._store.pipe(select(getLoading));
 }

  ngOnInit(): void {
    AOS.init();
  }

  createForm() {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
      rememberMe: ['']
    });
  }

  onSubmit(){
    this.user = this.loginForm.value;

    this._store.dispatch(new LogIn(this.user));
    this.completeAuth$.subscribe(x => {
      if(x === true){
        this.dialogRef.close();
      }
    });
  }

}
