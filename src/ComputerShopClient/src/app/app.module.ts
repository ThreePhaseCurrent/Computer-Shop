import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {JwtModule} from '@auth0/angular-jwt';

import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing/app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { MatDialogModule } from '@angular/material/dialog';
import {MatIconModule} from '@angular/material/icon';
import {MatCheckboxModule} from '@angular/material/checkbox';

import { baseURL } from './shared/baseurl';
import { HomeService } from './services/home.service';

import {ASSECC_TOKEN_KEY, AuthService} from './services/auth.service';
import { environment } from 'src/environments/environment';

import { FormsModule } from '@angular/forms'; 
import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

import {MatInputModule} from '@angular/material/input';

import 'hammerjs';
import { LoginComponent } from './login/login.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

export function tokenGetter(){
  return localStorage.getItem(ASSECC_TOKEN_KEY);
}

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    LoginComponent
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
    MatInputModule,
    MatCheckboxModule,
    MatProgressSpinnerModule,

    JwtModule.forRoot({
      config: {
        tokenGetter,
        whitelistedDomains: environment.tokenWhitelistedDomains
      }
    }),

    FontAwesomeModule

    ],
  providers: [HomeService, {provide: 'BaseUrl', useValue: baseURL}, AuthService],
  entryComponents: [LoginComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
