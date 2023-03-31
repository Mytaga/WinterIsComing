using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Common.Constants;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Comment;

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

        [HttpGet("getResortComments/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AllCommentsDto))]
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("add/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AddCommentDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddComment(string id, [FromBody]AddCommentDto model)
        {
            var resort = await this.resortService.GetByIdAsync(id);

            if (resort == null)
            {
                return NotFound();
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ExceptionErrors.InvalidModel);
            }

            await this.commentService.AddComment(model, resort);

            return Ok(model);
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("delete/{resortId}/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string resortId, string userId)
        {
            var resort = await this.resortService.GetByIdAsync(resortId);

            if (resort == null)
            {
                return NotFound();
            }

            if (userId == null)
            {
                return BadRequest();
            }

            var result = await this.commentService.DeleteComment(resort, userId);

            return Ok(result);
        }
    }
}
