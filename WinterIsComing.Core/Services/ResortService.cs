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

        public ResortService(IRepository repo)
        {
            this.repo = repo;
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
                    ImageUrl = r.ImageUrl,
                    Likes = r.Likes,
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
    }
}
