using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIIE.Controllers.Helpers;
using SIIE.Controllers.Engine;
using SIIE.Models;

namespace SIIE.Controllers
{
    [RoutePrefix("")]
    [SessionAuthorize]
    public class HomeController : Controller
    {
        private StudentEngine StudentEngine;

        [Route("")]
        [SessionAuthorize]
        public ActionResult Index()
        {
            if (Session["level"].ToString() == "1")
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                StudentEngine = new StudentEngine(Session["controlNumber"].ToString());
                var Data = StudentEngine.UserData();
                var Schedule = StudentEngine.getSchedule();
                return View(Tuple.Create(Schedule, Data));
            }
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
            if (userId != -1)
                userId = Convert.ToInt32(Session["userId"]);
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}