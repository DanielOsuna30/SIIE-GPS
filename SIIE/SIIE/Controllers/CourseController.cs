﻿using System;
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
        private AdminEngine AEngine;

        // GET: Course
        [Route("")]
        [SessionAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Cursando")]
        [SessionAuthorize(Users = "3")]
        public JsonResult SemesterSchedule()
        {
            StudentEngine = new StudentEngine(Session["controlNumber"].ToString());
            var S=StudentEngine.getSchedule();
            return Json(S);
        }

        [Route("Cursando/{controlNumber:int}")]
        [SessionAuthorize(Users ="1,2")]
        public JsonResult SemesterSchedule(int controlNumber)
        {
            StudentEngine = new StudentEngine(controlNumber.ToString());
            var Schedule=StudentEngine.getSchedule();
            return Json(Schedule);
        }

        [Route("Historial_Academico")]
        [SessionAuthorize(Users ="3")]
        public ActionResult AcademicHistory()
        {
            StudentEngine = new StudentEngine(Session["controlNumber"].ToString());
            var AH = StudentEngine.getAcademicHistory();
            return View(AH);
        }

        [Route("Historial_Academico/{controlNumber:int}")]
        [SessionAuthorize(Users = "1,2")]
        public JsonResult AcademicHistory(int controlNumber)
        {
            StudentEngine = new StudentEngine(controlNumber.ToString());
            var AH = StudentEngine.getAcademicHistory();
            return Json(AH);
        }
    }
}