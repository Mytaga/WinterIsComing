using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Contracts
{
    public interface ILikeService
    {
        Task LikeResort(Resort resort, string userId);

        Task UnlikeResort(Resort resort, string userId);

        Task<ICollection<Like>> LoadAllResortLikesAsync(string resortId);
    }
}
