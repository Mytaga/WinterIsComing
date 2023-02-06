using System.Net.Http.Headers;
using WinterIsComing.Core.Models;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Contracts
{
    public interface IResortService
    {
        Task<AllResortsDto> GetAllAsync(string? country = null, string? searchQuery = null);

        Task<ICollection<ResortPriceDto>> LoadResortPrices(string id);

        Task LikeResort(Resort resort, string UserId);

        Task UnlikeResort(Resort resort, string UserId);

        Task<Resort> GetByIdAsync(string id);
    }
}
