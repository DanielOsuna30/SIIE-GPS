using SIIE.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
            return View();
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
                Session["id"] = 1;
                Session["userType"] = 0;
                return Json(new { success = true, route= ConfigurationManager.AppSettings["MainRoute"] }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message="Usuario o contraseña no correctos" }, JsonRequestBehavior.AllowGet);
            }
        }

        private bool VerifyCredentials(int user,string password)
        {
            return true;
        }
    }
}