using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using HB.Vendas.Online.Logging.Log4Net;
using Microsoft.AspNetCore.Routing;

namespace HB.Vendas.Online.Filters.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            var exception = context.Exception;

            //Log Error
            Logger.Log(exception.Message, LogType.Error);

            //Redirect to Error View
            context.ExceptionHandled = true;            
            context.Result = new RedirectToRouteResult(new RouteValueDictionary
            {
                { "controller", "Home" },
                { "action", "Error" },                
            });

            //HttpResponse response = context.HttpContext.Response;
            //response.StatusCode = (int)status;
            //response.ContentType = "application/json";
            //context.Result = new JsonResult(exception);
        }
    }
}