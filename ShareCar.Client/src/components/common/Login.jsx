// @flow
import React, { Component } from "react";
import FacebookLogin from "react-facebook-login";

import history from "../../helpers/history";
import AuthenticationService from "../../services/authenticationService";
import logo from '../../images/shareCarLogo.png';

import "../../styles/login.css";

class Login extends Component<{}> {
  authService: AuthenticationService = new AuthenticationService();

  responseFacebook = (response: any) => {
    this.authService.loginWithFacebook(
      response.accessToken,
      this.userAuthenticated
    );
  };

  userAuthenticated = () => {
    history.push("/");
  };

  render() {
    return (
      <div className="login-container">
      <img className="login-image" src={logo} />
        <h1>ShareCar Login</h1>
        <FacebookLogin
          appId="599580833757975"
          fields="name,email,picture"
          callback={this.responseFacebook}
        />
      </div>
    );
  }
}

export default Login;
