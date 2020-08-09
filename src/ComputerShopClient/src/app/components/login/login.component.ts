import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user = {username: '', password: '', remember: false};

  constructor(private authService: AuthService) {
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
        },
      errorMsg => {
        this.loginError = <any>errorMsg;
      });
  }

}
