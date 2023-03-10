using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Core.Contracts;
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

        [Authorize]
        [HttpPost("Like/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LikeResort(string id)
        {
            var resort = await this.resortService.GetByIdAsync(id);

            if (resort == null)
            {
                return NotFound();
            }

            var userId = this.User.Id();

            if (userId == null)
            {
                return BadRequest();
            }

            await this.likeService.LikeResort(resort, userId);

            return NoContent();
        }


        [Authorize]
        [HttpPost("Unlike/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UnlikeResort(string id)
        {
            var resort = await this.resortService.GetByIdAsync(id);

            if (resort == null)
            {
                return NotFound();
            }

            var userId = this.User.Id();

            if (userId == null)
            {
                return BadRequest();
            }

            await this.likeService.UnlikeResort(resort, userId);

            return NoContent();
        }      
    }
}
