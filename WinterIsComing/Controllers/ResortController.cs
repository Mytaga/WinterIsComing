using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models;

namespace WinterIsComing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResortController : ControllerBase
    {
        private readonly IResortService resortService;

        public ResortController(IResortService resortService)
        {
            this.resortService = resortService;
        }

        [HttpGet("GetAll")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AllResortsDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll([FromQuery]string? country, string? searchQuery = null)
        {
            var result = await this.resortService.GetAllAsync(country, searchQuery);
            return Ok(result);
        }
    }
}
