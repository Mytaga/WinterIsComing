using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Resort;
using WinterIsComing.Extensions;

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
        public async Task<IActionResult> GetAll([FromQuery] string? country, string? searchQuery = null)
        {
            var result = await this.resortService.GetAllAsync(country, searchQuery);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetLiked")]
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

        [Authorize]
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var resort = await this.resortService.GetByIdAsync(id);
            var result = await this.resortService.GetResortDetailsAsync(resort);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("TopLiked")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AllResortsDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> TopLiked()
        {
            var result = await this.resortService.TopLiked();
            return Ok(result);
        }
    }
}
