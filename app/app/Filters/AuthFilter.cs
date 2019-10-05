using app.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace app.Filters
{
    public class AuthFilter : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext context)
        {
            var sessionTime = context.HttpContext.Request.Cookies["session_time"];
            var userLogin = context.HttpContext.Request.Cookies["user_login"];

            if (sessionTime != null)
            {
                if (Parsers.ParseDate(sessionTime.Value) > DateTime.Now)
                {
                    var expiresTime = DateTime.Now.AddMinutes(5);
                    
                    sessionTime.Value = expiresTime.ToString("dd/MM/yyyy hh:mm:ss tt");
                    sessionTime.Expires = expiresTime.AddHours(2);                                        
                    userLogin.Expires = expiresTime.AddHours(2);

                    context.HttpContext.Response.Cookies.Add(sessionTime);
                    context.HttpContext.Response.Cookies.Add(userLogin);
                }
                else
                {
                    context.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary
                        { { "controller", "authentication" }, { "action", "login" }});
                }
            }
            else
            {                
                context.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary
                        { { "controller", "authentication" }, { "action", "login" }});
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext context)
        {
            var user = context.HttpContext.User;
            //if (user == null)
            //{
            //    context.Result = new RedirectToRouteResult(
            //        new System.Web.Routing.RouteValueDictionary {
            //        { "controller", "home" }, { "action", "index" }
            //       });
            //}
        }
    }

    //public class ActionAttribute : FilterAttribute, IActionFilter
    //{
    //    public void OnActionExecuted(ActionExecutedContext context)
    //    {
    //        HttpCookie user_session = new HttpCookie("user_settings");
    //        var userSss = context.HttpContext.Request.Cookies["user_settings"];

    //        if (true)
    //        {
    //            HttpCookie userSets = new HttpCookie("user_settings");
    //            //HttpSessionState.["user_session"] = "Tom";

    //            userSets["user_session"] = Guid.NewGuid().ToString();
    //            userSets.Expires = DateTime.Now.AddMinutes(1d);

    //            context.HttpContext.Response.Cookies.Add(userSets);
    //        }
    //    }

    //    public void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        if (context.HttpContext.Request.Browser.Browser == "Opera")
    //        {
    //            context.Result = new HttpNotFoundResult();
    //        }
    //    }
    //}

    public class IndexException : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is IndexOutOfRangeException)
            {
                exceptionContext.Result = new RedirectResult("/Content/ExceptionFound.html");
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}
