import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';

import { authConfig } from './../auth.config';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css'],
})
export class AccountComponent implements OnInit {
  constructor(private oauthService: OAuthService) {
    oauthService.configure(authConfig);
    oauthService.tokenValidationHandler = new JwksValidationHandler();
    oauthService.loadDiscoveryDocumentAndTryLogin();
  }

  public login() {
    debugger;
    this.oauthService.initLoginFlow();
  }

  public logoff() {
    this.oauthService.logOut();
  }

  public get name() {
    let claims = this.oauthService.getIdentityClaims();
    debugger;
    if (!claims) return null;
    return 'baby';
  }

  ngOnInit(): void {}
}
