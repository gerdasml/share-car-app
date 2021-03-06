﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ShareCar.Dto;


namespace ShareCar.Logic.RideRequest_Logic
{
    public interface IRideRequestLogic
    {
        Task<IEnumerable<RideRequestDto>> GetUsersRequests(bool driver, string email);
        bool UpdateRequest(RideRequestDto request);
        bool AddRequest(RideRequestDto request, string driverEmail);
        void SeenByPassenger(int[] requests);
        void SeenByDriver(int[] requests);
        bool DeletedRide(int rideId);
        List<RideRequestDto> GetAcceptedRequests(string passengerEmail);
    }
}
