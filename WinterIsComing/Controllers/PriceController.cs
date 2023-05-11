using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Price;

namespace WinterIsComing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService priceService;
        private readonly ILogger logger;

        public PriceController(IPriceService priceService, ILogger<PriceController> logger)
        {
            this.priceService = priceService;
            this.logger = logger;   
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("add")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AddPriceDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPrice([FromBody] AddPriceDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await this.priceService.AddPriceAsync(model);

                return Ok(model);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside the Add action: {ex}");
                return StatusCode(500, "Internal server error");
            }          
        }
    }
}
