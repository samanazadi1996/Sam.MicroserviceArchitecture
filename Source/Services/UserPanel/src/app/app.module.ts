import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {OAuthService,OAuthModule } from "angular-oauth2-oidc";
import { HttpClientModule } from '@angular/common/http';
import { AccountComponent } from './account/account.component';


@NgModule({
  declarations: [
    AppComponent,
    AccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule ,
    OAuthModule.forRoot()
  ],
  providers: [OAuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
