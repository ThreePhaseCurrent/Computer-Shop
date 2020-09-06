import { Routes } from '@angular/router';
import { HomeComponent } from '../components/home/home.component';
import { SigninComponent } from '../components/signin/signin.component';
import { Login } from '../models/login';
import { LoginComponent } from '../components/login/login.component';
import { AuthGuard } from './auth-guard';
import {ProductViewComponent} from "../components/product/product-view/product-view.component";

export const routes: Routes = [
    {path: '', redirectTo: '/home', pathMatch: 'full'},
    {path: 'home', component: HomeComponent},
    {path: 'signin', component: SigninComponent},
    {path: 'login', component: LoginComponent},
    {path: 'products', component: ProductViewComponent}
];
