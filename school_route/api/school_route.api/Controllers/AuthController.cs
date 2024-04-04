using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using school_route.api.Dto;
using school_route.infrastructure.Log;
using school_route.models;
using school_route.services.interfaces;

namespace school_route.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        private readonly ILoggerHelper _logger;

        public AuthController(IUserServices userServices, IMapper mapper, ILoggerHelper logger)
        {
            this._userServices = userServices;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequestDto userRequestLoginDto, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInfo("Here is AuthController -> Login.");
                var userRequestLoginModel = this._mapper.Map<UserLoginModel>(userRequestLoginDto);
                var userResponseLoginModel = await this._userServices.LoginAsync(userRequestLoginModel, cancellationToken);
                var userResponseLoginDto = this._mapper.Map<UserLoginResponseDto>(userResponseLoginModel);
                return userResponseLoginDto != null ? Ok(userResponseLoginDto) : NotFound("User not found");
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }
    }
}