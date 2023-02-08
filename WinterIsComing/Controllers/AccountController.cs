using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IUserService userService;

        public AccountController(UserManager<AppUser> userManager, IUserService userService)
        {
            this.userManager = userManager;
            this.userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new AppUser()
            {
                Email = model.Email,
                EmailConfirmed = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return Ok(result.Errors);
            }

            foreach (var item in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, item.Description);
            }

            return this.StatusCode(201);
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await this.userService.Authenticate(model.Email, model.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect!" });
            }

            var tokenString = this.userService.GenerateJSONWebToken(user);

            return Ok( new { token = tokenString });    
        }
    }
}
