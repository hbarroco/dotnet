using HB.Vendas.Online.Presentation.Models.Infra;
using HB.Vendas.Online.Presentation.Utilities.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HB.Vendas.Online.Presentation.Utilities.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private bool _allowAnonymous { get; set; }

        private AuthorizationRoles? _authorizationRoles;

        public CustomAuthorizationFilter()
        {
            this._authorizationRoles = null;
        }

        public CustomAuthorizationFilter(AuthorizationRoles _authorizationRoles)
        {
            this._authorizationRoles = _authorizationRoles;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var userHasAccess = true;
            var userLogged = AuthenticationHandler.UserLogged();
            var controllerInfo = filterContext.ActionDescriptor as ControllerActionDescriptor;

            //Check is current controller/action have AllowAnonymous
            foreach (var filterDescriptors in filterContext.ActionDescriptor.FilterDescriptors)
            {
                if (filterDescriptors.Filter.GetType() == typeof(AllowAnonymousFilter))
                {
                    return;
                }
            }

            if (!userLogged)
                userHasAccess = false;
            else
            {
                var currentUser = AuthenticationHandler.GetCurrentUser();
                if (this._authorizationRoles != null && this._authorizationRoles != currentUser.Role)
                    userHasAccess = false;
            }

            if (!userHasAccess)
            {
                if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    filterContext.Result = new JsonResult("")
                    {
                        Value = new
                        {
                            Status = "Error"
                        },
                    };
                }
                else
                {
                    if (userLogged)
                    {
                        filterContext.Result = new RedirectToRouteResult(
                         new RouteValueDictionary {
                           {
                            "Controller",
                            "Home"
                           }, {
                            "Action",
                            "Privacy"
                           }
                         });
                    }
                    else {
                        filterContext.Result = new RedirectToRouteResult(
                         new RouteValueDictionary {
                           {
                            "Controller",
                            "Home"
                           }, {
                            "Action",
                            "Login"
                           }
                         });
                    }

                }
            }
        }
    }
}