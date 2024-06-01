import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {
  // Url of the Identity Provider
  issuer: 'https://localhost:5001',
  // loginUrl:'https://localhost:5001/Account/Login',
  // URL of the SPA to redirect the user to after login
  redirectUri: window.location.origin + '/',

  // The SPA's id. The SPA is registered with this id at the auth-server
  clientId: 'UserPanel.Angular',

  // set the scope for the permissions the client should request
  // The first three are defined by OIDC. The 4th is a usecase-specific one
  scope: 'openid profile UserPanel.Angular',
  resource:"UserPanel.Angular",
  nonceStateSeparator:"UserPanel.Angular",
  responseType:"code"
}
