﻿using Microsoft.AspNetCore.Identity;
using System;

namespace ShareCar.Db.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? FacebookId { get; set; }
        public long? GoogleId { get; set; }
        public string FacebookEmail { get; set; }
        public string GoogleEmail { get; set; }
        public bool FacebookVerified { get; set; }
        public bool GoogleVerified { get; set; }
        public string CognizantEmail { get; set; }
        public string PictureUrl { get; set; }
        public string LicensePlate { get; set; }
        public string Phone { get; set; }
        public DateTime CreationDate {get;set;}
    }
}