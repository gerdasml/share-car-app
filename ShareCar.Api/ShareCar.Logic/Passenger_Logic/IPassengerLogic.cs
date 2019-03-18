﻿using ShareCar.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareCar.Logic.Passenger_Logic
{
    public interface IPassengerLogic
    {
        void AddPassenger(PassengerDto passenger);
        void RemovePassenger(string email, int rideId);
        int GetUsersPoints(string email);
        List<PassengerDto> GetUnrepondedPassengersByEmail(string email);
        List<PassengerDto> GetPassengersByRideId(int rideId);
        void RespondToRide(bool response, int rideId, string passengerEmail);
    }
}
