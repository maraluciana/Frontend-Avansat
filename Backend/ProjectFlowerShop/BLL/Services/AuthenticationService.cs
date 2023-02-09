using Microsoft.AspNetCore.Identity;
using ProjectFlowerShop.BLL.Interfaces;
using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenService tokenService;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager,
            ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        public async Task Register(RegisterUserModel registerUserModel)
        {
            var user = new User
            {
                Email = registerUserModel.Email,
                UserName = registerUserModel.UserName
            };

            var result = await userManager.CreateAsync(user, registerUserModel.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, registerUserModel.Role);
            }
        }

        public async Task<TokenModel> Login(LoginUserModel loginUserModel)
        {
            var user = await userManager.FindByEmailAsync(loginUserModel.Email);
            if (user == null)
                return new TokenModel
                {
                    Success = false
                };
            else
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginUserModel.Password, false);
                if (result.Succeeded)
                {
                    var token = await tokenService.CreateAccessToken(user);
                    var refreshToken = tokenService.CreateRefreshToken();

                    user.RefreshToken = refreshToken;
                    await userManager.UpdateAsync(user);

                    return new TokenModel
                    {
                        Success = true,
                        AccessToken = token,
                        RefreshToken = refreshToken
                    };
                }
                else
                    return new TokenModel
                    {
                        Success = false
                    };
            }
        }
    }
}