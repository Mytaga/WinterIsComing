using WinterIsComing.Core.Models.Resort;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Contracts
{
    public interface IResortService
    {
        Task<AllResortsDto> GetAllAsync(string? country = null, string? searchQuery = null);

        Task<ICollection<ResortPriceDto>> LoadResortPrices(string id);

        Task<Resort> GetByIdAsync(string id);

        Task<AllResortsDto> GetLikedAsync(string userId);

        Task<ResortDetailsDto> GetResortDetailsAsync(Resort resort);

        Task<AllResortsDto> TopLiked();
    }
}
