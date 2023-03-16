using Microsoft.EntityFrameworkCore;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Country;
using WinterIsComing.Core.Models.Resort;
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
                searchQuery = $"{searchQuery.ToLower()}%";

                resorts = resorts.Where(r => EF.Functions.Like(r.Name, searchQuery));
            }

            result.Resorts = await resorts
                .Select(r => new ResortDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Elevation = r.Elevation,
                    Likes = r.Likes.Count(),
                    ImageUrl = r.ImageUrl,
                    CountryName = r.Country.Name,
                })
                .OrderBy(r => r.Name)
                .ToListAsync();

            return result;
        }

        public async Task<Resort> GetByIdAsync(string id)
        {
            return await this.repo
                .All<Resort>()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ICollection<ResortPriceDto>> LoadResortPrices(string id)
        {
            var result = await this.repo
                .AllReadonly<Price>()
                .Where(p => p.ResortId == id)
                .Select(p => new ResortPriceDto
                {
                    Id = p.Id,
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
                   ImageUrl = r.ImageUrl,
                   Likes = r.Likes.Count(),
                   CountryName = r.Country.Name,
               })
               .ToListAsync();

            return result;
        }

        public async Task<ResortDetailsDto> GetResortDetailsAsync(Resort resort)
        {
            var result = new ResortDetailsDto
            {
                Id = resort.Id,
                Name = resort.Name,
                Elevation = resort.Elevation,
                Description = resort.Description,
                ImageUrl = resort.ImageUrl,
                Likes = resort.Likes.Count(),
                NumberOfSlopes = resort.NumberOfSlopes,
                SkiAreaSize = resort.SkiAreaSize,
                CountryName = resort.Country.Name,
            };

            result.LiftPrices = await this.LoadResortPrices(resort.Id);

            return result;
        }

        public async Task<AllResortsDto> TopLiked()
        {
            var result = new AllResortsDto();

            var resorts = this.repo.AllReadonly<Resort>()
                .OrderByDescending(r => r.Likes)
                .Take(10);

            result.Resorts = await resorts
               .Select(r => new ResortDto
               {
                   Id = r.Id,
                   Name = r.Name,
                   Elevation = r.Elevation,
                   ImageUrl = r.ImageUrl,
                   Likes = r.Likes.Count(),
                   CountryName = r.Country.Name,
               })
               .ToListAsync();

            return result;
        }

        public async Task<ICollection<CountryDto>> LoadCountriesAsync()
        {
            return await this.repo.
                AllReadonly<Country>()
                .Select(c => new CountryDto
                {
                    Id = c.Id,  
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task AddResortAsync(AddResortDto resort)
        {
            var Resort = new Resort()
            {
                Name = resort.Name,
                Elevation = resort.Elevation,
                ImageUrl = resort.ImageUrl,
                Description = resort.Description,
                NumberOfSlopes = resort.NumberOfSlopes,
                SkiAreaSize = resort.SkiAreaSize,
                CountryId = resort.CountryId,
            };
            
            await this.repo.AddAsync(Resort);

            await this.repo.SaveChangesAsync();
        }

        public async Task<ICollection<ResortNameDto>> LoadResortsNamesAsync()
        {
            return await this.repo.
                 AllReadonly<Resort>()
                 .Select(c => new ResortNameDto
                 {
                     Id = c.Id,
                     Name = c.Name,
                 })
                 .ToListAsync();
        }
    }
}
