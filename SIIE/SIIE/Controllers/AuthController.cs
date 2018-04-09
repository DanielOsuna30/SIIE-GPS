using SIIE.Controllers.Engine;
using SIIE.Controllers.Helpers;
using SIIE.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SIIE.Controllers
{
    [RoutePrefix("Login")]
    public class AuthController : Controller
    {
        AuthEngine Engine=new AuthEngine();

        [HttpGet]
        [Route("")]
        [NotLoggedAuthorize]
        public ActionResult Index()
        {
            if (HttpContext.Session["userType"] == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Verificación de credenciales en la db
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [NotLoggedAuthorize]
        public JsonResult Login(Loginn Data)
        {
            Engine.VerifyCredentials(ref Data);
            if (Data!=null)
            {
                Session["controlNumber"] = Data.noControl;
                Session["level"] = Data.Permiso;
                return Json(new { status=HttpStatusCode.OK, route= ConfigurationManager.AppSettings["MainRoute"] }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { status=HttpStatusCode.BadRequest, message="Usuario o contraseña incorrectos" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPatch]
        [Route("")]
        [SessionAuthorize]
        public JsonResult Logout()
        {
            Session.Clear();
            return Json(new { status = HttpStatusCode.OK, route = ConfigurationManager.AppSettings["MainRoute"] + "Login/" }, JsonRequestBehavior.AllowGet);
        }

    }
}