using school_route.models;
using System.Security.Claims;

namespace school_route.infrastructure.JwtToken
{
    public interface ITokenHelper
    {
        string GenerateJWT(IEnumerable<Claim>? additionalClaims = null);
        string GenerateJWT(UserLoginModel user, IEnumerable<Claim>? additionalClaims = null);
    }
}
