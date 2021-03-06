﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShareCar.Db.Entities;
using ShareCar.Dto.Identity;
using ShareCar.Dto.Identity.Facebook;

namespace ShareCar.Db.Repositories.User_Repository
{
    public interface IUserRepository
    {
        Task CreateFacebookUser(FacebookUserDataDto userDto);
        Task<UserDto> GetLoggedInUser(ClaimsPrincipal principal);
        Task<IdentityResult> UpdateUserAsync(User user, ClaimsPrincipal principal);
        IEnumerable<User> GetAllUsers();
    }
}