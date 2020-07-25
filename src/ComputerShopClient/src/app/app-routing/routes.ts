import { Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { SigninComponent } from '../signin/signin.component';
import { Login } from '../models/login';
import { LoginComponent } from '../login/login.component';
import { AuthGuard } from './auth-guard';

export const routes: Routes = [
    {path: '', redirectTo: '/home', pathMatch: 'full'},
    {path: 'home', component: HomeComponent},
    {path: 'signin', component: SigninComponent},
    {path: 'login', component: LoginComponent}
];
