using HB.Vendas.Online.Domain.Entities;
using HB.Vendas.Online.Logging.Log4Net;
using HB.Vendas.Online.Presentation.Utilities.Filters;
using HB.Vendas.Online.Presentation.Models;
using HB.Vendas.Online.Presentation.Models.Infra;
using HB.Vendas.Online.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HB.Vendas.Online.Presentation.Controllers
{
    [CustomAuthorizationFilter]
    public class HomeController : Controller
    {
        private readonly ISampleService sampleService;
        private readonly IUserService userService;
        private readonly IStoreService storeService;

        public HomeController(ISampleService sampleService, IUserService userService, IStoreService storeService)
        {
            this.sampleService = sampleService;
            this.userService = userService;
            this.storeService = storeService;
        }

        public IActionResult Index()
        {
            sampleService.Add(new Sample { Description = "Helio" + Guid.NewGuid() });
            Logger.Log("Sample Inserido", LogType.Info);

            var xx = sampleService.GetUsingDapper();
            return View();
        }

        //[CustomAuthorizationFilter(AuthorizationRoles.UserWithPrivileges)]
        public IActionResult About()
        {
            var x = sampleService.GetAll();

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //[CustomAuthorizationFilter(AuthorizationRoles.Administrator)]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(int? id)
        {
            var userDTO = new UserDTO();
            var listStoresDTO = AutoMapper.Mapper.Map<List<StoreDTO>>(storeService.GetAll());
            userDTO.Stores = listStoresDTO;

            if (id == 0)
                Utilities.Authentication.AuthenticationHandler.LogOut();
            else
            {
                if (Utilities.Authentication.AuthenticationHandler.UserLogged())
                    return RedirectToAction("Menu", "Home");
            }

            return View(userDTO);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserDTO userDto)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetByUserNamePasswordAndStore(userDto.UserName, userDto.Password, userDto.StoreId);
                Utilities.Authentication.AuthenticationHandler.Loggin(user);

                return RedirectToAction("Menu", "Home");
            }

            var userDTO = new UserDTO();
            var listStoresDTO = AutoMapper.Mapper.Map<List<StoreDTO>>(storeService.GetAll());
            userDTO.Stores = listStoresDTO;

            return View(userDTO);
        }

        public IActionResult Menu()
        {
            IPrincipal iPrincipalUser = User;

            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;

            var userClaimsList = HttpContext.User.Claims.ToList();

            return View();
        }
    }
}
