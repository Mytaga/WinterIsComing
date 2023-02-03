using WinterIsComing.Core.Models;

namespace WinterIsComing.Core.Contracts
{
    public interface IResortService
    {
        Task<AllResortsDto> GetAllAsync(string? country = null, string? searchQuery = null);

        Task<ICollection<ResortPriceDto>> LoadResortPrices(string id);
    }
}
