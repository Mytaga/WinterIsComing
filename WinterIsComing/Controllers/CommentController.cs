using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Common.Constants;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Comment;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IResortService resortService;
        private readonly ILogger<CommentController> logger;

        public CommentController(ICommentService commentService, IResortService resortService, ILogger<CommentController> logger)
        {
            this.commentService = commentService;
            this.resortService = resortService;
            this.logger = logger;
        }

        [HttpGet("{resortId}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AllCommentsDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetResortComments(string resortId)
        {
            var resort = await this.resortService.GetByIdAsync(resortId);

            if (resort == null)
            {
                return NotFound();
            }

            try
            {
                var result = await this.commentService.GetResortComments(resort);

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.GetResortComments, ex); 

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }           
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{id}")]
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

            try
            {
                await this.commentService.AddComment(model, resort);

                return Ok(model);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.AddComment, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(CommentDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(string id, [FromBody] AddCommentDto model)
        {
            var comment = await this.commentService.GetById(id);

            if (comment == null)
            {
                return NotFound();
            }

            try
            {
                await this.commentService.EditComment(model, comment);

                return Ok(model);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.EditComment, ex); 

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }       
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(Comment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetComment(string id)
        {
            var result = await this.commentService.GetById(id);

            try
            {
                if (result == null)
                {
                    return BadRequest();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.GetComment, ex); 

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{resortId}/{userId}")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(CommentDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteComment(string resortId, string userId)
        {
            var resort = await this.resortService.GetByIdAsync(resortId);

            if (resort == null)
            {
                return NotFound();
            }

            if (userId == null)
            {
                return Unauthorized();
            }

            try
            {
                var result = await this.commentService.DeleteComment(resort, userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.DeleteComment, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        // Test Signed Commit
    }
}
