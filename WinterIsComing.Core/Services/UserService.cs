using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Infrastructure.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WinterIsComing.Core.Models;
using WinterIsComing.Core.Models.Resort;

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

        public async Task<UserProfileDto> GetUserProfile(string userId)
        {
            
            var user = await this.userManager.FindByIdAsync(userId);

            var result = new UserProfileDto
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImageUrl = user.ImageUrl,
                MyResorts = user.FavouriteResorts.Select(r => new ResortDto 
                {
                    Id = r.Id,
                    Name = r.Name,
                    Elevation = r.Elevation,
                    ImageUrl = r.ImageUrl,
                    Likes = r.Likes.Count(),
                    CountryName = r.Country.Name,
                })
                .ToList(),
            };

            return result;
        }

        public async Task<IdentityResult> Register(RegisterDto model)
        {
            var user = new AppUser()
            {
                Email = model.Email,
                EmailConfirmed = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            return result;
        }

        public async Task UpdateProfile(UpdateUserProfileDto model, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.ImageUrl = model.ImageUrl;

            await this.userManager.UpdateAsync(user);
        }
    }
}
