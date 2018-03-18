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
        [InscriptionAuthorize]
        public JsonResult Inscripcion(CourseModels.InscriptionData Data)
        {
            if (IEngine.GetStatus())
                return Json(new { status=HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { status=HttpStatusCode.Unauthorized}, JsonRequestBehavior.AllowGet);
        }

        [Route("Inscripcion/Update")]
        [SessionAuthorize(Users ="1")]
        public ActionResult InscriptionUpdate()
        {
            return View();
        }

        [HttpPost]
        [Route("Inscripcion/Update")]
        [SessionAuthorize(Users ="1")]
        public JsonResult InscriptionUpdate(CourseModels.InscriptionUpdate Data)
        {
            return Json(new { status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("Inscripcion/Update")]
        [InscriptionAuthorize]
        public JsonResult InscripcionUpdate(CourseModels.InscriptionUpdate Data)
        {
            return Json(new { status=HttpStatusCode.OK },JsonRequestBehavior.AllowGet)
        }

        /// <summary>
        /// Vista para reinscribirse
        /// </summary>
        /// <returns></returns>
        [Route("Reinscripcion")]
        [ReinscriptionAuthorize]
        public ActionResult Reinscripcion()
        {
            if (Session["userType"].ToString() != "3")
                return View("~/Views/ReinscripcionNoStudent.cshtml");
            else
                return View();
        }

        /// <summary>
        /// Ingresar materias de reinscripcion
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Reinscripcion")]
        [ReinscriptionAuthorize]
        public JsonResult Reinscripcion(CourseModels.ReinscriptionData Data)
        {
            return Json(new { status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Actualizar reinscripcion
        /// </summary>
        /// <returns></returns>
        [Route("Reinscripcion/Update")]
        [SessionAuthorize(Users="1")]
        public ActionResult ReinscriptionUpdate()
        {
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
        public JsonResult ReinscriptionUpdate(CourseModels.ReinscriptionUpdate Data)
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
            DocumentsManager Dm = new Helpers.DocumentsManager();
            string fileName = Dm.ReinscriptionFoil(userId);
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.WriteFile(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" + fileName);
            Response.End();
            FileInfo fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Content\\Templates\\" + fileName);
            fileInfo.Delete();
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

    }
}