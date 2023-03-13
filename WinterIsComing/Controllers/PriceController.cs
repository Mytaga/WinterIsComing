using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Price;
using WinterIsComing.Core.Models.Resort;

namespace WinterIsComing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService priceService;

        public PriceController(IPriceService priceService)
        {
            this.priceService = priceService;
        }

        [HttpPost("add")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AddPriceDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddPrice([FromBody] AddPriceDto model)
        {
            await this.priceService.AddPriceAsync(model);

            return Ok(model);
        }
    }
}
