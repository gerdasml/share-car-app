﻿using ShareCar.Dto.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareCar.Dto.Identity
{
    public class RequestDto
    {
        public int RequestId { get; set; }
        public string PassengerEmail { get; set; }
        public string DriverEmail { get; set; }
        public int AddressId { get; set; }
        public Status Status { get; set; }

    }
    public enum Status
    {
        WAITING,
        ACCEPTED,
        DENIED
    }
}