namespace LoginJWT_Sample_API.Models
{
    public record struct AuthResponseDto(Guid UserId, string Name, string Email, string Role,  string Token);    
}
