// @flow
import React, { Component } from "react";
import FacebookLogin from "react-facebook-login";
import history from "../helpers/history";
import AuthenticationService from "../services/authenticationService";
import "../styles/login.css";
import logo from '../images/shareCarLogo.png';

class Login extends Component<{}> {
  authService: AuthenticationService = new AuthenticationService();

  responseFacebook = (response: any) => {
    console.log(response);

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
      <div className="loginContainer">
      <img src={logo} />
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