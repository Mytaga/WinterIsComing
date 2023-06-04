using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinterIsComing.Common.Constants;
using WinterIsComing.Core.Contracts;
using WinterIsComing.Core.Models.Country;
using WinterIsComing.Core.Models.Resort;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Controllers
{
    [Route("api/resorts")]
    [ApiController]
    public class ResortController : ControllerBase
    {
        private readonly IResortService resortService;
        private readonly ILogger<ResortController> logger;

        public ResortController(IResortService resortService, ILogger<ResortController> logger)
        {
            this.resortService = resortService;
            this.logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AllResortsDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll([FromQuery] string? country, string? searchQuery)
        {
            try
            {
                var result = await this.resortService.GetAllAsync(country, searchQuery);

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.GetAll, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{userId}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AllResortsDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetLiked(string userId)
        {
            if (userId == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await this.resortService.GetLikedAsync(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.GetLiked, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(ResortDetailsDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var resort = await this.resortService.GetByIdAsync(id);

                var result = await this.resortService.GetResortDetailsAsync(resort);

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.Details, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [HttpGet("top")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AllResortsDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> TopLiked()
        {
            try
            {
                var result = await this.resortService.TopLiked();

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.TopLiked, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [HttpGet("countries")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(ICollection<CountryDto>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var result = await this.resortService.LoadCountriesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.GetCountries, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(Resort))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddResort([FromBody] AddResortDto model)
        {
            try
            {
                var result = await this.resortService.AddResortAsync(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.AddResort, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [HttpGet("names")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(ResortNameDto))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetResortsNames()
        {
            try
            {
                var result = await this.resortService.LoadResortsNamesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.GetNames, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(ResortDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteResort(string id)
        {
            var resort = await this.resortService.GetByIdAsync(id);

            if (resort == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await this.resortService.DeleteResortAsync(resort);

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.DeleteResort, ex);

                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }
    }
}
