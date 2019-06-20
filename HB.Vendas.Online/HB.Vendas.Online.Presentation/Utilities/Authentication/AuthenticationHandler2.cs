using HB.Vendas.Online.Domain.Entities;
using HB.Vendas.Online.Presentation.Models.Infra;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace HB.Vendas.Online.Presentation.Utilities.Authentication
{
    public class AuthenticationHandler2
    {
        public async void Loggin(User entity)
        {
            if (entity == null || entity.Id <= 0)
                throw new AuthenticationException("Usuário não encontrado no sistema");

            // Create the identity from the user info
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ClaimTypes.Name, entity.Name));
            identity.AddClaim(new Claim("UserName", entity.UserName));            
            identity.AddClaim(new Claim("IdUsuario", entity.Id.ToString()));
            // You can add roles to use role-based authorization
            identity.AddClaim(new Claim(ClaimTypes.Role, "Usuario"));

            // Authenticate using the identity
            var principal = new ClaimsPrincipal(identity);
            await Helpers.AppContext.Current.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });
        }

        public async void LogOut()
        {
            await Helpers.AppContext.Current.SignOutAsync();
            Helpers.AppContext.Current.Response.Cookies.Delete(".AspNetCore.Cookies");
        }

        public LoggedUser GetCurrentUser()
        {

            var name = Helpers.AppContext.Current.User.Identity.Name;
            var claims = Helpers.AppContext.Current.User.Claims;

            foreach (var claim in claims)
            {
                var x = claim.Value;
                var y = claim.Type;
            }

            return new LoggedUser();
        }

        public static bool UserLogged()
        {
            return true;
        }
    }
}
