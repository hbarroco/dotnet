namespace LoginJWT_Sample_API.Models
{    public readonly record struct LoggedInUserDto(Guid Id, string Name, string Role, string Email);
}
