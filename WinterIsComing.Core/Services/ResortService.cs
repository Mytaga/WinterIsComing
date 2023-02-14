using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models;
using WinterIsComing.Infrastructure.Data.Common;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Services
{
    public class ResortService : IResortService
    {
        private readonly IRepository repo;
        private readonly UserManager<AppUser> userManager;

        public ResortService(IRepository repo, UserManager<AppUser> userManager)
        {
            this.repo = repo;
            this.userManager = userManager;
        }

        public async Task<AllResortsDto> GetAllAsync(string? country = null, string? searchQuery = null)
        {
            var result = new AllResortsDto();

            var resorts = this.repo.AllReadonly<Resort>();

            if (string.IsNullOrEmpty(country) == false)
            {
                resorts = resorts.Where(r => r.Country.Name == country);
            }

            if (string.IsNullOrEmpty(searchQuery) == false)
            {
                searchQuery = $"%{searchQuery.ToLower()}%";

                resorts = resorts.Where(r => EF.Functions.Like(r.Name, searchQuery));
            }

            result.Resorts = await resorts
                .Select(r => new ResortDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Elevation = r.Elevation,
                    Description = r.Description,
                    Likes = r.Likes.Count(),
                    ImageUrl = r.ImageUrl,
                    NumberOfSlopes = r.NumberOfSlopes,
                    SkiAreaSizes = r.SkiAreaSizes,
                    CountryName = r.Country.Name,
                })
                .ToListAsync();

            foreach (var resort in result.Resorts)
            {
                resort.LiftPrices = await this.LoadResortPrices(resort.Id);
            }

            return result;
        }

        public async Task<Resort> GetByIdAsync(string id)
        {
            return await this.repo
                .All<Resort>()
                .FirstOrDefaultAsync(r => r.Id == id);
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

        public async Task<ICollection<ResortPriceDto>> LoadResortPrices(string id)
        {
            var result = await this.repo
                .AllReadonly<Price>()
                .Where(p => p.ResortId == id)
                .Select(p => new ResortPriceDto
                {
                    PassType = p.PassType.ToString(),
                    Price = p.Value,
                })
                .OrderBy(p => p.Price)
                .ToListAsync();

            return result;
        }

        public async Task<AllResortsDto> GetLikedAsync(string userId)
        {
            var result = new AllResortsDto();

            var resorts = this.repo.AllReadonly<Resort>().Where(r => r.Users.Any(u => u.Id == userId));

            result.Resorts = await resorts
               .Select(r => new ResortDto
               {
                   Id = r.Id,
                   Name = r.Name,
                   Elevation = r.Elevation,
                   Description = r.Description,
                   ImageUrl = r.ImageUrl,
                   Likes = r.Likes.Count(),
                   NumberOfSlopes = r.NumberOfSlopes,
                   SkiAreaSizes = r.SkiAreaSizes,
                   CountryName = r.Country.Name,
               })
               .ToListAsync();

            foreach (var resort in result.Resorts)
            {
                resort.LiftPrices = await this.LoadResortPrices(resort.Id);
            }

            return result;
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
