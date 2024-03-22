using LoginJWT_Sample_API.Models;
using LoginLogoutJWT_Sample.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginJWT_Sample_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public UsersController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            _logger.LogInfo("Here is UsersController -> GetAllUsers.");

            // Get users from Database
            var users = new UserDto[]
            {
                new (Guid.NewGuid(), "Helio", true),
                new (Guid.NewGuid(), "Camila", true),
                new (Guid.NewGuid(), "Sofia", false),
                new (Guid.NewGuid(), "Otavio", true),
                new (Guid.NewGuid(), "Other 1", false),
                new (Guid.NewGuid(), "Other 2", false)
            };
            return Ok(ApiResponseDto<UserDto[]>.Success(users));
        }
    }
}