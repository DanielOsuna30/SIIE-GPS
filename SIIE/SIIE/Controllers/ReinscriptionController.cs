using SIIE.Controllers.Engine;
using SIIE.Controllers.Helpers;
using SIIE.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static SIIE.Models.ReinscriptionModels;

namespace SIIE.Controllers
{
    [RoutePrefix("Reinscripcion")]
    public class ReinscriptionController : Controller
    {
        private ReinscriptionEngine Engine;

        // GET: Reinscription
        [Route("")]
        [ReinscriptionAuthorize]
        public ActionResult Index()
        {
            if (Session["userType"].ToString() != "3")
                return View("~/Views/ReinscripcionNoStudent.cshtml");
            else
                return View();
        }

        /// <summary>
        /// Obtener materias en formato json
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetData")]
        [ReinscriptionAuthorize(Users ="3")]
        public JsonResult GetReinscriptionSubjects()
        {
            return Json(new { subjects = "" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtener materias en formato json
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetData/{controlNumber:int}")]
        [ReinscriptionAuthorize(Users = "1,2")]
        public JsonResult GetReinscriptionSubjects(int controlNumber)
        {
            Engine = new ReinscriptionEngine(controlNumber.ToString());
            return Json(new { subjects = "" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Ingresar materias de reinscripcion de usuario logeado
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Finish")]
        [ReinscriptionAuthorize]
        public JsonResult FinishStudent(ReinscriptionData Data)
        {
            Engine = new ReinscriptionEngine(Session["controlNumber"].ToString());
            Engine.Finish(Data);
            return Json(new { status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Ingrsar materias de reinscripcion de usuario especifico
        /// </summary>
        /// <param name="controlNumber"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Finish/{controlNumber:int}")]
        public JsonResult Finish(int controlNumber, ReinscriptionData Data)
        {
            Engine = new ReinscriptionEngine(controlNumber.ToString());
            Engine.Finish(Data);
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        [Route("Update")]
        [SessionAuthorize(Users = "1")]
        public ActionResult Update()
        {
            return View();
        }

        /// <summary>
        /// Definir fechas, precios y limites para la reinscripcion de este semestre
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        [SessionAuthorize(Users = "1")]
        public JsonResult ReinscriptionUpdate(ReinscriptionUpdate Data)
        {
            Engine.UpdateStatus(Data);
            return Json(new { message = "Guardado", status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtener ficha de reinscripcion para alumno logeado
        /// </summary>
        /// <param name="UserData"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Ficha")]
        [SessionAuthorize]
        public ActionResult ReinscriptionFoil()
        {
            DocumentsManager Dm = new DocumentsManager(Response);
            Dm.ReinscriptionFoil(Convert.ToInt32(Session["controlNumber"]));
            return null;
        }

        /// <summary>
        /// Obtener ficha de reinscripcion para alumno especifico
        /// </summary>
        /// <param name="UserData"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Ficha/{controlNumber:int}")]
        [SessionAuthorize]
        public ActionResult ReinscriptionFoil(int controlNumber)
        {
            DocumentsManager Dm = new DocumentsManager(Response);
            Dm.ReinscriptionFoil(controlNumber);
            return null;
        }

    }
}