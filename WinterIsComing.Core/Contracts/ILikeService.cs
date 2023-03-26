using WinterIsComing.Core.Models.Like;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Contracts
{
    public interface ILikeService
    {
        Task<LikeDto> LikeResort(Resort resort, string userId);

        Task<LikeDto> UnlikeResort(Resort resort, string userId);

        Task<ICollection<LikeDto>> LoadAllResortLikesAsync(string resortId);
    }
}

