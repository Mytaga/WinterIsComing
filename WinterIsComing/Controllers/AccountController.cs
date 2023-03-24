using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Common.Constants;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models;
using WinterIsComing.Extensions;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(IUserService userService, SignInManager<AppUser> signInManager)
        {
            this.userService = userService;
            this.signInManager = signInManager;
        }

        [HttpPost("register")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.userService.Register(model);

            if (!result.Succeeded)
            {
                return Ok(result.Errors);
            }

            return this.StatusCode(201);
        }

        [HttpPost("login")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(LoginDto))]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await this.userService.Authenticate(model.Email, model.Password);

            if (user == null)
            {
                return BadRequest(new { message = ExceptionErrors.LoginError });
            }

            var tokenString = this.userService.GenerateJSONWebToken(user);

            await this.signInManager.SignInAsync(user, true);

            return Ok( new { token = tokenString, userName = user.UserName, id = user.Id, image = user.ImageUrl });    
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Produces("application/json")]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("viewProfile/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(UserProfileDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ViewProfile(string id)
        {
            var userId = this.User.Id();

            if (userId == null)
            {
                return NotFound();
            }

            var result = await this.userService.GetUserProfile(id);

            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("updateProfile/{id}")]
        [ProducesResponseType(400, StatusCode =StatusCodes.Status400BadRequest, Type = typeof(UserProfileDto))]
        [ProducesResponseType(204, StatusCode =StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateUserProfileDto model, string id)
        {
            var userId = this.User.Id();

            if (userId == null)
            {
                return BadRequest();
            }

            await this.userService.UpdateProfile(model, id);

            return NoContent();
        }
    }
}
