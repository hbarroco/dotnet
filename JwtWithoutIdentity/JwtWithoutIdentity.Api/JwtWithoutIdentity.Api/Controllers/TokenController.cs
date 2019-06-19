using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtWithoutIdentity.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JwtWithoutIdentity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public TokenController(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var name = User.Identity.Name;
            var claims = User.Claims;

            return new string[] { "value1", "value2" };
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Token(LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Token failed to generate");

            //Do the Login in DataBase
            //var user = (model.Password == "password" && model.UserName == "username");
            //if (!user) return Unauthorized();

            return Ok(await GerarJwt());
        }

        private async Task<string> GerarJwt()
        {
            //var claims = new[]
            //{
            //    new ClaimsIdentity(JwtRegisteredClaimNames.UniqueName, "data"),
            //    new Claim(JwtRegisteredClaimNames.Sub, "data"),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //};

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "Helio"),
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim("IdUsuario", "11111"),
            });

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,

                //Subject = new ClaimsIdentity(new[]
                //{
                //    new Claim(ClaimTypes.Name, user.Id)
                //}),
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
