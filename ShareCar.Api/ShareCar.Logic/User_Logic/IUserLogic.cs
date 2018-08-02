﻿using ShareCar.Dto.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShareCar.Logic.User_Logic
{
    public interface IUserLogic
    {
        Task<UserDto> GetUserAsync(ClaimsPrincipal principal);
        void UpdateUserAsync(UserDto updatedUser, ClaimsPrincipal User);
    }
}