using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIIE.Controllers.Helpers;
using SIIE.Controllers.Engine;

namespace SIIE.Controllers
{
    [RoutePrefix("")]
    [SessionAuthorize]
    public class HomeController : Controller
    {
        private StudentEngine SEngine;
        private AdminEngine AEngine;

        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Application Description";

            return View();
        }

        [AllowAnonymous]
        [Route("Unauthorized")]
        private ActionResult Unauthorized()
        {
            return new HttpStatusCodeResult(401);
        }

        [HttpPost]
        [Route("Dashboard/{userId:int}")]
        public JsonResult GetDashboardData(int userId)
        {
            if (userId == -1)
                userId = Convert.ToInt32(Session["userId"]);
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}