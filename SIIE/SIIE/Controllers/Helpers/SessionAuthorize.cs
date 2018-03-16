using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace SIIE.Controllers.Helpers
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class SessionAuthorize:AuthorizeAttribute
    {
        public string ResourceKey { get; set; }
        public string OperationKey { get; set; }

        /// <summary>
        /// Acceso denegado
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext Context)
        {
            if (Context.HttpContext.Session["userType"]==null)
                Context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Auth", action = "Index" })
                );
            else
                Context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Home", action = "Index" })
                );
        }

        /// <summary>
        /// Authorización por medio de session
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["userType"] == null)
                return false;
            if (Users != "" )
                if (Users.Contains(httpContext.Session["userType"].ToString()))
                    return true;
                else
                    return false;
            else
                return true;
        }
    }
}