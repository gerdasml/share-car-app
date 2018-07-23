﻿using ShareCar.Db.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ShareCar.Dto.Identity;
namespace ShareCar.Logic.ObjectMapping
{
    public class RideMapper
    {
        public Ride MapToEntity(RideDto ride)
        {
            throw new NotImplementedException();
        }

        public RideDto MapToDto(Ride ride)
        {
            PassengerMapper PassengerMapper = new PassengerMapper();
            RequestMapper RequestMapper = new RequestMapper();

            List<PassengerDto> DtoPassengers = new List<PassengerDto>();
            List<RequestDto> DtoRequests = new List<RequestDto>();


            foreach (var passenger in ride.Passengers)
            {
                DtoPassengers.Add(PassengerMapper.MapToDto(passenger));
            }

            foreach (var request in ride.Requests)
            {
                DtoRequests.Add(RequestMapper.MapToDto(request));
            }

            return new RideDto
            {
                RideId = ride.RideId,
                FromId = ride.FromId,
                ToId = ride.ToId,
                DriverEmail = ride.DriverEmail,
                RideDateTime = ride.RideDateTime,
                Passengers = DtoPassengers,
                Requests = DtoRequests

            };
        }

        public void MapEntityToEntity(Ride target, Ride example)
        {

            target.RideId = example.RideId;
            target.FromId = example.FromId;
            target.ToId = example.ToId;
            target.DriverEmail = example.DriverEmail;
            target.RideDateTime = example.RideDateTime;
            target.Passengers = example.Passengers;
            target.Requests = example.Requests;
            
        }

    }
}
