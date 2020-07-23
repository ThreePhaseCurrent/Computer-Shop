import { Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { SigninComponent } from '../signin/signin.component';
import { Login } from '../models/login';
import { LoginComponent } from '../login/login.component';

export const routes: Routes = [
    {path: 'home', component: HomeComponent },
    {path: '', redirectTo: '/home', pathMatch: 'full'},
    {path: 'signin', component: SigninComponent},
    {path: 'login', component: LoginComponent}
];
