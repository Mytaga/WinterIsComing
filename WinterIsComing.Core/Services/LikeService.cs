using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WinterIsComing.Core.Contracts;
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

        public async Task LikeResort(Resort resort, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var likes = await this.LoadAllResortLikesAsync(resort.Id);

            if (!likes.Any(l => l.AppUserId == userId))
            {
                Like like = new Like
                {
                    AppUserId = userId,
                    ResortId = resort.Id,
                };

                resort.Likes.Add(like);
                resort.Users.Add(user);
            };

            this.repo.Update(resort);

            await this.repo.SaveChangesAsync();
        }

        public async Task UnlikeResort(Resort resort, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var likes = await this.LoadAllResortLikesAsync(resort.Id);

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

        public async Task<ICollection<Like>> LoadAllResortLikesAsync(string resortId)
        {
            var likes = await this.repo
                .AllReadonly<Like>()
                .Where(l => l.ResortId == resortId)
                .ToListAsync();

            return likes;
        }
    }
}
