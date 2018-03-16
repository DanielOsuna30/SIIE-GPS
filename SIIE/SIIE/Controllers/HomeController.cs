using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIIE.Controllers.Helpers;


namespace SIIE.Controllers
{
    [RoutePrefix("")]
    [SessionAuthorize]
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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