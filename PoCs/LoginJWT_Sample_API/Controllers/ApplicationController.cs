using LoginJWT_Sample_API.Models;
using LoginLogoutJWT_Sample.Utility;
using Microsoft.AspNetCore.Mvc;

namespace LoginJWT_Sample_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public ApplicationController(ILoggerManager logger) {
            _logger = logger;
        }

        [HttpGet(Name = "GetApplicationDetails")]
        public IActionResult GetApplicationDetails()
        {
            _logger.LogInfo("Here is ApplicationController -> GetApplicationDetails.");

            // Get it from some config, AppSettings or Database
            var appDetails = new ApplicationDetailsDto("Login Flow with JWT", "1.0", DateTime.Now);
            return Ok(ApiResponseDto<ApplicationDetailsDto>.Success(appDetails));
        }
    }
}
