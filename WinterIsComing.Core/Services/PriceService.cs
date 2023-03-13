using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Price;
using WinterIsComing.Infrastructure.Data.Common;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Core.Services
{
    public class PriceService : IPriceService 
    {
        private readonly IRepository repo;

        public PriceService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task AddPriceAsync(AddPriceDto model)
        {
            var price = new Price()
            {
                PassType = model.PassType,
                Value = model.Value,
                ResortId = model.ResortId,
            };

            await this.repo.AddAsync(price);
            await this.repo.SaveChangesAsync();
        }
    }
}
