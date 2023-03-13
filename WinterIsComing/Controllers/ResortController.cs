using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Country;
using WinterIsComing.Core.Models.Resort;
using WinterIsComing.Extensions;
using WinterIsComing.Infrastructure.Data.Models;

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

        [HttpGet("getAll")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AllResortsDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll([FromQuery] string? country, string? searchQuery)
        {
            var result = await this.resortService.GetAllAsync(country, searchQuery);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("getLiked")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AllResortsDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetLiked()
        {
            var userId = this.User.Id();

            if (userId == null)
            {
                return BadRequest();
            }

            var result = await this.resortService.GetLikedAsync(userId);

            return Ok(result);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var resort = await this.resortService.GetByIdAsync(id);
            var result = await this.resortService.GetResortDetailsAsync(resort);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("topLiked")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AllResortsDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> TopLiked()
        {
            var result = await this.resortService.TopLiked();
            return Ok(result);
        }

        [HttpGet("loadCountries")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(ICollection<CountryDto>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCountries()
        {
            var result = await this.resortService.LoadCountriesAsync();

            return Ok(result);
        }

        [HttpPost("add")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AddResortDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddResort([FromBody] AddResortDto model)
        {
            await this.resortService.AddResortAsync(model);

            return Ok(model);
        }
    }
}
