using Microsoft.AspNetCore.Identity;
using WinterIsComing.Core.Models;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Contracts
{
    public interface IUserService
    {
        Task<AppUser> Authenticate(string email, string password);

        string GenerateJSONWebToken(AppUser user);

        Task<IdentityResult> Register(RegisterDto model);

        Task<UserProfileDto> GetUserProfile(string userId); 
    }       
}
