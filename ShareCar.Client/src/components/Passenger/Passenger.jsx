// @flow
import React, { Component } from "react";

import UserService from "../../services/userService";
import { ViewRideRequests } from "../Driver/Ride/ViewRideRequests";

export default class Driver extends Component<{}, MyProfileState> {
  userService = new UserService();
  state: MyProfileState = { loading: true, user: null };

  componentDidMount() {
    this.userService.getLoggedInUser(this.updateLoggedInUser);
  }

  updateLoggedInUser = (user: UserProfileData) => {
    this.setState({ loading: false, user: user });
  };

  render() {
    const content = this.state.loading ? (
      <p>
        <em>Loading..</em>
      </p>
    ) : this.state.user == null ? (
      <p>Failed</p>
    ) : (
      <div className="role-container">
        <ViewRideRequests driver={false} />
      </div>
    );
    return <div>{content}</div>;
  }
}
