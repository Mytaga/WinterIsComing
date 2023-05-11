using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Common.Constants;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Like;

namespace WinterIsComing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService likeService;
        private readonly IResortService resortService;
        private readonly ILogger<LikeController> logger;

        public LikeController(ILikeService likeService, IResortService resortService, ILogger<LikeController> logger)
        {
            this.likeService = likeService;
            this.resortService = resortService;
            this.logger = logger;
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

            try
            {
                var result = await this.likeService.LikeResort(resort, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.LikeResort, ex);
                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }         
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

            try
            {
                var result = await this.likeService.UnlikeResort(resort, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.UnlikeResort, ex); ;
                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
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

            try
            {
                var result = await this.likeService.LoadAllResortLikesAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.GetResortLikes, ex); ;
                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex); ;
            }          
        }
    }
}
