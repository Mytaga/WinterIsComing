using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Like;
using WinterIsComing.Extensions;

namespace WinterIsComing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService likeService;
        private readonly IResortService resortService;

        public LikeController(ILikeService likeService, IResortService resortService)
        {
            this.likeService = likeService;
            this.resortService = resortService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("like/{id}/{userId}")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(LikeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LikeResort(string id, string userId)
        {
            var resort = await this.resortService.GetByIdAsync(id);

            if (resort == null)
            {
                return NotFound();
            }

            if (userId == null)
            {
                return BadRequest();
            }

            var result = await this.likeService.LikeResort(resort, userId);

            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("unlike/{id}/{userId}")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(LikeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UnlikeResort(string id, string userId)
        {
            var resort = await this.resortService.GetByIdAsync(id);

            if (resort == null)
            {
                return NotFound();
            }

            if (userId == null)
            {
                return BadRequest();
            }

            var result = await this.likeService.UnlikeResort(resort, userId);

            return Ok(result);
        }

        [HttpGet("getResortLikes/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(ICollection<LikeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetResortLikes(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var result = await this.likeService.LoadAllResortLikesAsync(id);

            return Ok(result);
        }
    }
}
