using WinterIsComing.Core.Models.Price;

namespace WinterIsComing.Core.Contracts
{
    public interface IPriceService
    {
        Task AddPriceAsync (AddPriceDto model);
    }
}
