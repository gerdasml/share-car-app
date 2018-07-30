﻿using ShareCar.Db.Entities;
using ShareCar.Dto.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareCar.Logic.Identity
{
    public interface IPersonLogic
    {
        void AddPerson(Person person);
        PersonDto GetPersonByEmail(string email);
    }
}
