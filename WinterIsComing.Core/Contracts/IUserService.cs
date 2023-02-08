using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Contracts
{
    public interface IUserService
    {
        Task<AppUser> Authenticate(string email, string password);

        string GenerateJSONWebToken(AppUser user);
    }       
}
