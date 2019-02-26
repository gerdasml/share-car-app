﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ShareCar.Db.Entities;
using ShareCar.Db.Repositories.User_Repository;
using ShareCar.Dto.Identity;
using ShareCar.Dto.Identity.Facebook;
using ShareCar.Dto.Identity.Google;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShareCar.Logic.User_Logic
{
    public class GoogleIdentity : IGoogleIdentity
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly IUserRepository _userRepository;
        private static readonly HttpClient Client = new HttpClient();

       public GoogleIdentity(UserManager<User> userManager, IJwtFactory jwtFactory, IUserRepository userRepository)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _userRepository = userRepository;
        }
        
        public async Task<string> Login(GoogleUserDataDto userInfo)
        {
            // ready to create the local user account (if necessary) and jwt
            var user = await _userManager.FindByEmailAsync(userInfo.Email);

            if (user == null)
            {
                await _userRepository.CreateUser(new UserDto {
                    FirstName = userInfo.GivenName,
                    LastName = userInfo.FamilyName,
                    Email = userInfo.Email,
                    PictureUrl = userInfo.ImageUrl
                });
            }

            // generate the jwt for the local user
            var localUser = await _userManager.FindByNameAsync(userInfo.Email);

            if (localUser == null)
            {
                throw new ArgumentException("Local user account could not be found.");
            }

            var jwt = await GenerateJwt(localUser);

            return jwt;
        }

        private async Task<string> GenerateJwt(User localUser)
        {
            var jwtIdentity = _jwtFactory.GenerateClaimsIdentity(localUser.UserName, localUser.Id);
            var jwt = await _jwtFactory.GenerateEncodedToken(localUser.UserName, jwtIdentity);

            return jwt;
        }
    }
}
