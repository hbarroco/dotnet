namespace LoginJWT_Sample_API.Models
{
  public record struct UserDto(Guid Id, string Name, bool IsActive);
}
