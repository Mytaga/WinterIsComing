using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Common.Constants;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Price;

namespace WinterIsComing.Controllers
{
    [Route("api/price")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService priceService;
        private readonly ILogger<PriceController> logger;

        public PriceController(IPriceService priceService, ILogger<PriceController> logger)
        {
            this.priceService = priceService;
            this.logger = logger;   
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AddPriceDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPrice([FromBody] AddPriceDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await this.priceService.AddPriceAsync(model);

                return Ok(model);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.AddPrice, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }          
        }
    }
}
