﻿using ShareCar.Db.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShareCar.Logic.Ride_Logic
{
   public interface IRideRepository
    {
        Ride FindRideById(int id);
        IEnumerable<Ride> FindRidesByDriver(string email);
        IEnumerable<Ride> FindRidesByDate(DateTime date);
        IEnumerable<Ride> FindRidesByDestination(int addressToId);
        IEnumerable<Ride> FindRidesByStartPoint(int addressFromId);
        IEnumerable<Passenger> FindPassengersByRideId(int rideId);
 //       Task<IEnumerable<Passenger>> FindRidesByPassenger(ClaimsPrincipal User);
        bool UpdateRide(Ride ride);
        void AddRide(Ride ride);
    }
}