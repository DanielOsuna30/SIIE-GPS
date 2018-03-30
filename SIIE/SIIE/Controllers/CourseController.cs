using System;
using System.Web.Mvc;
using SIIE.Controllers.Helpers;
using SIIE.Controllers.Engine;
using SIIE.Models;
using System.IO;
using System.Net;

namespace SIIE.Controllers
{
    [RoutePrefix("Curso")]
    public class CourseController : Controller
    {
        private StudentEngine StudentEngine;

        // GET: Course
        [Route("")]
        [SessionAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Cursando")]
        [SessionAuthorize(Users = "3")]
        public ActionResult SemesterSchedule()
        {
            StudentEngine = new StudentEngine(Convert.ToInt32(Session["controlNumber"]));
            var S=StudentEngine.getSchedule();
            return View(S);
        }

        [Route("Cursando/{controlNumber:int}")]
        [SessionAuthorize(Users ="1,2")]
        public ActionResult SemesterSchedule(int controlNumber)
        {
            StudentEngine = new StudentEngine(controlNumber);
            var Schedule=StudentEngine.getSchedule();
            return View(Schedule);
        }

        [Route("Historial_Academico")]
        [SessionAuthorize(Users ="3")]
        public ActionResult AcademicHistory()
        {
            StudentEngine = new StudentEngine(Convert.ToInt32(Session["controlNumber"]));
            var AH = StudentEngine.getAcademicHistory();
            return View(AH);
        }

        [Route("Historial_Academico/{controlNumber:int}")]
        [SessionAuthorize(Users = "1,2")]
        public ActionResult AcademicHistory(int controlNumber)
        {
            StudentEngine = new StudentEngine(controlNumber);
            var AH = StudentEngine.getAcademicHistory();
            return View(AH);
        }


    }
}