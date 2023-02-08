﻿using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Infrastructure.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WinterIsComing.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IConfiguration configuration;

        public UserService(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<AppUser> Authenticate(string email, string password)
        {
            var user = await this.userManager.FindByEmailAsync(email);

            if (user != null && this.userManager.CheckPasswordAsync(user, password).Result)
            {
                return user;
            }

            return null;
        }

        public string GenerateJSONWebToken(AppUser user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),   
            };

            var autoSignInkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: this.configuration["JWT:ValidIssuer"],
                audience: this.configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials:
                new SigningCredentials(autoSignInkey, SecurityAlgorithms.HmacSha256));
                

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}
