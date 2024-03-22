using LoginJWT_Sample_API.Models;

namespace LoginJWT_Sample_API.Services
{
    public interface IAuthService
    {
        Task<ApiResponseDto<AuthResponseDto>> LoginAsync(LoginRequestDto loginDto, CancellationToken cancellationToken = default);
    }

    public sealed class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<ApiResponseDto<AuthResponseDto>> LoginAsync(LoginRequestDto loginDto, CancellationToken cancellationToken = default)
        {
            // Inject UserRepo
            // Get the User Info from Database
            // Validate Password

            var user = new LoggedInUserDto(Guid.NewGuid(), "Abhay Prince", "Admin", "useremail@fakegmail.com");

            var jwt = _tokenService.GenerateJWT(user);
            var authResponse = new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                Name = user.Name,
                Role = user.Role,
                Token = jwt
            };
            return ApiResponseDto<AuthResponseDto>.Success(authResponse);
        }
    }
}
