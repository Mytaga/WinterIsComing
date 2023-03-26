using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Like;
using WinterIsComing.Infrastructure.Data.Common;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Services
{
    public class LikeService : ILikeService
    {
        private readonly IRepository repo;
        private readonly UserManager<AppUser> userManager;

        public LikeService(IRepository repo, UserManager<AppUser> userManager)
        {
            this.repo = repo;
            this.userManager = userManager;
        }

        public async Task<LikeDto> LikeResort(Resort resort, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var likes = await this.LoadAllResortLikesAsync(resort.Id);
            Like like = new Like();

            if (!likes.Any(l => l.UserId == userId))
            {
                like.AppUserId = userId;
                like.ResortId = resort.Id;

                await this.repo.AddAsync<Like>(like);
                resort.Likes.Add(like);
                resort.Users.Add(user);
            };

            this.repo.Update(resort);

            var model = new LikeDto
            {
                ResortId = resort.Id,
                UserId = userId,
            };

            await this.repo.SaveChangesAsync();

            return model;
        }

        public async Task UnlikeResort(Resort resort, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var likes = await this.repo.All<Like>().Where(l => l.ResortId == resort.Id).ToListAsync();

            if (likes.Any(l => l.AppUserId == userId))
            {
                var like = likes.FirstOrDefault(l => l.AppUserId == userId);
                resort.Likes.Remove(like);
                resort.Users.Remove(user);
                this.repo.Delete<Like>(like);
            }

            this.repo.Update(resort);

            await this.repo.SaveChangesAsync();
        }

        public async Task<ICollection<LikeDto>> LoadAllResortLikesAsync(string resortId)
        {
            var likes = await this.repo
                .AllReadonly<Like>()
                .Where(l => l.ResortId == resortId)
                .Select(l => new LikeDto
                {
                    ResortId = l.ResortId,
                    UserId = l.AppUserId,
                })
                .ToListAsync();

            return likes;
        }
    }
}
