using SIIE.Controllers.Engine;
using SIIE.Controllers.Helpers;
using SIIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static SIIE.Models.InscriptionModels;

namespace SIIE.Controllers
{
    [RoutePrefix("Inscripcion")]
    public class InscriptionController : Controller
    {
        InscriptionEngine Engine;

        [Route("")]
        [InscriptionAuthorize]
        public ActionResult Index()
        {
            if (Session["userType"].ToString() != "3")
                return View("~/Views/InscripcionNoStudent.cshtml");
            else
                return View();
        }

        /// <summary>
        /// Ingresar datos de inscripcion
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [InscriptionAuthorize]
        public JsonResult Data(InscriptionData Data)
        {
            Engine = new InscriptionEngine(Session["controlNumber"].ToString());
            return Json(new { status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

        [Route("Update")]
        [SessionAuthorize(Users = "1")]
        public ActionResult Update()
        {
            return View();
        }

        /// <summary>
        /// Definir datos para la inscripcion de este semestre
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        [SessionAuthorize(Users = "1")]
        public JsonResult Update(InscriptionUpdate Data)
        {
            Engine.UpdateStatus(Data);
            return Json(new { message = "Guardado", status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtener ficha de inscripcion para alumno logeado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Ficha")]
        [InscriptionAuthorize]
        public ActionResult Foil()
        {
            DocumentsManager Dm = new DocumentsManager(Response);
            Dm.InscriptionFoil(Convert.ToInt32(Session["controlNumber"]));
            return null;
        }

        /// <summary>
        /// Obtener ficha de inscripcion para alumno especifico
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Ficha/{controlNumber:int}")]
        [SessionAuthorize]
        public ActionResult Foil(int controlNumber)
        {
            DocumentsManager Dm = new DocumentsManager(Response);
            Dm.InscriptionFoil(controlNumber);
            return null;
        }

    }
}