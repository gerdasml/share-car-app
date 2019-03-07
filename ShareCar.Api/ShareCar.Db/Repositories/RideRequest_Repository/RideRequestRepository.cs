﻿using System.Collections.Generic;
using ShareCar.Db.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace ShareCar.Db.Repositories.RideRequest_Repository
{
   public class RideRequestRepository : IRideRequestRepository
    {

        private readonly ApplicationDbContext _databaseContext;


        public RideRequestRepository(ApplicationDbContext context)
        {
            _databaseContext = context;
        }


        public void AddRequest(RideRequest request)
        {
                _databaseContext.Requests.Add(request);
                _databaseContext.SaveChanges();
        }

        public IEnumerable<RideRequest> GetDriverRequests(string email)
        {

                return _databaseContext.Requests.Where(x => x.DriverEmail == email && x.Status == Status.WAITING).ToList();

        }

        public IEnumerable<RideRequest> GetRequestsByRideId(int rideId)
        {
            return _databaseContext.Requests.Where(x => x.RideId == rideId && x.Status != Status.DELETED).ToList();
        }

        public void DeletedRide(IEnumerable<RideRequest> requests)
        {
                foreach (RideRequest request in requests)
                {
                    RideRequest toUpdate = _databaseContext.Requests.Find(request.RequestId);
                    if (toUpdate == null)
                    {
                    throw new ArgumentException("User not found.");
                    }
                    toUpdate.SeenByPassenger = false;
                    toUpdate.Status = Status.DELETED;
                }
                _databaseContext.SaveChanges();
        }

        public IEnumerable<RideRequest> GetPassengerRequests(string email)
        {
            return _databaseContext.Requests.Where(x => x.PassengerEmail == email && (x.SeenByPassenger == false || (x.Status != Status.DENIED && x.Status != Status.DELETED))).ToList();
        }

        public RideRequest GetRequestById(int id)
        {
                return _databaseContext.Requests.Find(id);
        }

        public IEnumerable<RideRequest> GetAcceptedRequests(string passengerEmail)
        {
            return _databaseContext.Requests.Where(x => x.PassengerEmail == passengerEmail && x.Status == Status.DENIED).ToList();
        }

        public void SeenByDriver(int[] requests)
        {

                foreach (int id in requests)
                {
                    RideRequest toUpdate = _databaseContext.Requests.Single(x => x.RequestId == id);
                    toUpdate.SeenByDriver = true;
                }

                _databaseContext.SaveChanges();
            }

        public void SeenByPassenger(int[] requests)
        {
            IEnumerable<RideRequest> toUpdate = _databaseContext.Requests.Where(x => requests.Contains(x.RequestId));

            foreach (var request in toUpdate)
            {
                request.SeenByPassenger = true;
            }
            _databaseContext.SaveChanges();
        }

        public void UpdateRequest(RideRequest request)
        {

                RideRequest toUpdate = _databaseContext.Requests.Single(x => x.RequestId == request.RequestId);
                toUpdate.Status = request.Status;
                toUpdate.SeenByPassenger = false;
                _databaseContext.Requests.Update(toUpdate);
                _databaseContext.SaveChanges();
        }

        
    }
}
