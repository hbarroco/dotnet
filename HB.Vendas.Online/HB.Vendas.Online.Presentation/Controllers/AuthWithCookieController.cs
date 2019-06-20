using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HB.Vendas.Online.Domain.Entities;
using HB.Vendas.Online.Presentation.Models;
using HB.Vendas.Online.Presentation.Utilities.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HB.Vendas.Online.Presentation.Controllers
{
    [Authorize]
    public class AuthWithCookieController : Controller
    {

        private readonly AuthenticationHandler2 _authenticationHandler2;

        public AuthWithCookieController(AuthenticationHandler2 authenticationHandler2)
        {
            this._authenticationHandler2 = authenticationHandler2;            
        }

        [Authorize(Roles = "Usuario")]
        public IActionResult Index()
        {
            var name = User.Identity.Name;
            var claims = User.Claims;

            foreach (var claim in claims)
            {
                var x = claim.Value;
                var y = claim.Type;
            }

            var c = this._authenticationHandler2.GetCurrentUser();

            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel entity)
        {
            if (ModelState.IsValid)
            {
                var isValid = true; // TODO Validate the username and the password with your own logic
                if (!isValid)
                {
                    ModelState.AddModelError("", "username or password is invalid");
                    //return Page();
                }

                var userAutenticated = new User
                {
                    Id = 999, Name = "Hélio Barroco", UserName = "hbarroco"
                };

                this._authenticationHandler2.Loggin(userAutenticated);

                //// Create the identity from the user info
                //var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "hbarroco"));
                //identity.AddClaim(new Claim(ClaimTypes.Name, "Helio Barroco"));
                //// You can add roles to use role-based authorization
                //identity.AddClaim(new Claim(ClaimTypes.Role, "Usuario"));

                //// Authenticate using the identity
                //var principal = new ClaimsPrincipal(identity);
                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });

                return RedirectToAction("Index", "AuthWithCookie");
            }

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            //await HttpContext.SignOutAsync();
            //HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            this._authenticationHandler2.LogOut();
            return RedirectToAction("Index", "AuthWithCookie");
        }
    }
}