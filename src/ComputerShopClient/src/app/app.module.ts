import { BrowserModule } from '@angular/platform-browser';
import { NgModule, InjectionToken } from '@angular/core';
import { JwtModule } from '@auth0/angular-jwt';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { MatInputModule } from '@angular/material/input';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgxIntlTelInputModule } from 'ngx-intl-tel-input';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AlertModule } from 'ngx-bootstrap/alert';
import { CollapseModule } from 'ngx-bootstrap/collapse';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { SigninComponent } from './components/signin/signin.component';

import { HomeService } from './services/home.service';
import {ACCESS_TOKEN_KEY, AuthService} from './services/auth.service';

import { AuthGuard } from './app-routing/auth-guard';
import { environment } from 'src/environments/environment';
import { baseURL } from './shared/baseurl';

import { appReducers } from './store/reducers/app.reducers';

//import 'hammerjs';
import { AuthEffects } from './store/effects/auth.effects';
import {HttpErrorsInterceptorService} from "./interceptors/httperrors.interceptor";
import { ProductDetailComponent } from './components/product/product-detail/product-detail.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductViewComponent } from './components/product/product-view/product-view.component';

export const ROOT_REDUCER = new InjectionToken<any>('Root Reducer',
{factory: () => (appReducers)});

export function tokenGetter(){
  return localStorage.getItem(ACCESS_TOKEN_KEY);
}

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    LoginComponent,
    SigninComponent,
    ProductDetailComponent,
    ProductListComponent,
    ProductViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatDialogModule,
    FormsModule,
    MatSliderModule,
    MatToolbarModule,
    FlexLayoutModule,
    MatGridListModule,
    MatListModule,
    MatSidenavModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    EffectsModule.forRoot([AuthEffects]),
    MatInputModule,
    MatCheckboxModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    BsDropdownModule.forRoot(),
    AlertModule.forRoot(),
    CollapseModule.forRoot(),

    ReactiveFormsModule,
    NgxIntlTelInputModule,
    StoreModule.forRoot(ROOT_REDUCER),

    MDBBootstrapModule.forRoot(),

    JwtModule.forRoot({
      config: {
        tokenGetter,
        whitelistedDomains: environment.tokenWhitelistedDomains
      }
    }),

    FontAwesomeModule,
    ],
  providers: [HomeService, AuthService, AuthGuard,
    { provide: 'BaseUrl', useValue: baseURL },
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorsInterceptorService, multi: true }
    ],
  entryComponents: [LoginComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
