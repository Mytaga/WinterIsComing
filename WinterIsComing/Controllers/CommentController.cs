using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Common.Constants;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Comment;
using WinterIsComing.Extensions;

namespace WinterIsComing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IResortService resortService;

        public CommentController(ICommentService commentService, IResortService resortService)
        {
            this.commentService = commentService;
            this.resortService = resortService;
        }

        [Authorize]
        [HttpGet("GetResortComments/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(ICollection<CommentDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetResortComments(string id)
        {
            var resort = await this.resortService.GetByIdAsync(id);

            if (resort == null)
            {
                return NotFound();
            }

            var result = await this.commentService.GetResortComments(resort);

            return Ok(result);
        }

        [Authorize]
        [HttpPost("AddComment/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddComment(string id, [FromBody]AddCommentDto model)
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

            if (!ModelState.IsValid)
            {
                return BadRequest(ExceptionErrors.InvalidModel);
            }

            await this.commentService.AddComment(model, resort, userId);

            return NoContent();
        }


        [Authorize]
        [HttpDelete("DeleteComment/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var comment = await this.commentService.GetById(id);
            var userId = this.User.Id();

            if (comment == null)
            {
                return NotFound();
            }

            if (userId == null || comment.AppUserId != userId)
            {
                return Unauthorized();
            }

            await this.commentService.DeleteComment(comment);

            return NoContent();
        }
    }
}
