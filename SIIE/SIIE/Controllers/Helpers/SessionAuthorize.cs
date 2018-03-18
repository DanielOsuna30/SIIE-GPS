using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace SIIE.Controllers.Helpers
{

    /// <summary>
    /// Revision de permisos de Session
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class SessionAuthorize:AuthorizeAttribute
    {
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

    /// <summary>
    /// Revision si ya es fecha de Inscripcion
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class InscriptionAuthorize:AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext Context)
        {
            if (Context.HttpContext.Session["userType"] == null)
                Context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Auth", action = "Index" })
                );
            else
                Context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Home", action = "Index" })
                );
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["userType"] == null)
                return false;
            if (Users != "")
                if (Users.Contains(httpContext.Session["userType"].ToString()))
                    return true;
                else
                    return false;
            else
                return true;
        }
    }

    /// <summary>
    /// Revision si ya es fecha de Reinscripcion
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class ReinscriptionAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext Context)
        {
            if (Context.HttpContext.Session["userType"] == null)
                Context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Auth", action = "Index" })
                );
            else
                Context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Home", action = "Index" })
                );
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["userType"] == null)
                return false;
            if (Users != "")
                if (Users.Contains(httpContext.Session["userType"].ToString()))
                    return true;
                else
                    return false;
            else
                return true;
        }
    }
}