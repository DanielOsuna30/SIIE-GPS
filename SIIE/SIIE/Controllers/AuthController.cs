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
        [HttpGet]
        [Route("")]
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
        public JsonResult Login(UserModels.User Data)
        {
            if (VerifyCredentials(Data.ControlNumber, Data.Password))
            {
                Session["controlNumber"] = Data.ControlNumber;
                Session["userType"] = 1;
                return Json(new { status=HttpStatusCode.OK, route= ConfigurationManager.AppSettings["MainRoute"] }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { status=HttpStatusCode.Unauthorized, message="Usuario o contraseña incorrectos" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Verificar credenciales de login en la db
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool VerifyCredentials(int user,string password)
        {
            return true;
        }
    }
}