using LoginJWT_Sample_API.Models;
using LoginJWT_Sample_API.Services;
using LoginLogoutJWT_Sample.Utility;
using Microsoft.AspNetCore.Mvc;

namespace LoginJWT_Sample_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILoggerManager _logger;

        public AuthController(IAuthService authService, ILoggerManager logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto dto, CancellationToken cancellationToken = default)
        {
            _logger.LogInfo("Here is AuthController -> Login.");
            var response = await _authService.LoginAsync(dto, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}