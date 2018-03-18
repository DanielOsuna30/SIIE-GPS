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
    [SessionAuthorize]
    public class CourseController : Controller
    {
        private ReinscriptionEngine REngine;
        private InscriptionEngine IEngine;
           
        // GET: Course
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Inscripcion")]
        [InscriptionAuthorize]
        public ActionResult Inscripcion()
        {
                return View();
        }

        /// <summary>
        /// Recibe informacion de alumno de nuevo ingreso 
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Inscripcion")]
        public JsonResult Inscripcion(CourseModels.InscriptionData Data)
        {
            if (IEngine.GetStatus())
                return Json(new { status=HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { status=HttpStatusCode.Unauthorized}, JsonRequestBehavior.AllowGet);
        }

        [Route("Reinscripcion")]
        public ActionResult Reinscripcion()
        {
            if (Session["userType"].ToString() != "3")
                return View("~/Views/ReinscripcionNoStudent.cshtml");
            else
                return View();
        }

        /// <summary>
        /// Definir fechas, precios y limites para la reinscripcion de este semestre
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Reinscripcion/Update")]
        [SessionAuthorize(Users="1")]
        public JsonResult UpdateReinscriptionStatus(CourseModels.ReinscriptionData Data)
        {
            REngine.UpdateStatus();
            return Json(new { message="Guardado",status= HttpStatusCode.OK}, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtener ficha de reinscripcion para alumnos
        /// </summary>
        /// <param name="UserData"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Reinscripcion/Ficha")]
        [SessionAuthorize(Users = "2,3")]
        public ActionResult ReinscriptionFoil(string userId = "")
        {
            if (REngine.ReinscriptionStatus())
            {
                DocumentsManager Dm = new Helpers.DocumentsManager();
                string fileName = Dm.ReinscriptionFoil(userId);
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.WriteFile(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" + fileName);
                Response.End();
                FileInfo fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" + fileName);
                fileInfo.Delete();
            }
            return null;
        }

        /// <summary>
        /// Obtener materias en formato json 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ReinscripcionData")]
        public JsonResult GetReinscriptionSubjects(string userId="")
        {
            return Json(new { subjects = "" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Recibir materias elegidas por usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ReinscripcionData")]
        public JsonResult SetReinscriptionSubjects(string userId="")
        {
            return Json(new { subjects = "" }, JsonRequestBehavior.AllowGet);
        }

    }
}