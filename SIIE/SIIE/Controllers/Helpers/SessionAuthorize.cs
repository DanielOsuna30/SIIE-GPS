using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using SIIE.Controllers.Engine;

namespace SIIE.Controllers.Helpers
{

    /// <summary>
    /// Estanadar para las clases
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeGeneral : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext Context)
        {
            if (Context.HttpContext.Session["controlNumber"] == null)
                Context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Auth", action = "Index" })
                );
            else
                Context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Home", action = "Index" })
                );
        }

        public bool getLoginData(HttpContextBase httpContext)
        {
            if (httpContext.Session["controlNumber"] == null)
                return false;
            if (Users != "")
                if (Users.Contains(httpContext.Session["level"].ToString()))
                    return true;
                else
                    return false;
            else
                return true;
        }
    }

    /// <summary>
    /// Revision de permisos de Session
    /// </summary>
    public class SessionAuthorize : AuthorizeGeneral
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return getLoginData(httpContext);
        }
    }

    /// <summary>
    /// Revision que no haya un usuario loggeado
    /// </summary>
    public class NotLoggedAuthorize : AuthorizeGeneral
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["controlNumber"] == null)
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// Revision si ya es fecha de Inscripcion
    /// </summary>
    public class InscriptionAuthorize : AuthorizeGeneral
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["controlNumber"] == null)
            {
                InscriptionEngine Ie = new InscriptionEngine();

                if (!Ie.GetStatus())
                    return false;
                return true;
            }
            else
                return false;

        }
    }

    /// <summary>
    /// Revision si ya es fecha de Reinscripcion
    /// </summary>
    public class ReinscriptionAuthorize : AuthorizeGeneral
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            {
                if (httpContext.Session["controlNumber"] != null)
                {
                    ReinscriptionEngine Re = new ReinscriptionEngine();

                    if (!Re.GetStatus())
                        return false;
                    return getLoginData(httpContext);
                }
                else
                    return false;
            }
        }
    }
}