using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIIE.Controllers.Helpers;
using SIIE.Models;
using System.IO;
using System.Net;

namespace SIIE.Controllers
{
    [RoutePrefix("Curso")]
    [SessionAuthorize]
    public class CourseController : Controller
    {
        // GET: Course
        [Route("")]
        public ActionResult Index()
        {
            return View();
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
        public JsonResult SetupReinscriptionStatus(CourseModels.ReinscriptionData Data)
        {
            return Json(new { message="Guardado",status= HttpStatusCode.OK}, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Revisar si ya es fecha de reinscripcion
        /// </summary>
        /// <returns></returns>
        private bool ReinscriptionStatus()
        {
            return false;
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
            if (ReinscriptionStatus())
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
        [Route("ReinscriptionData")]
        public JsonResult SetReinscriptionSubjects(string userId="")
        {
            return Json(new { subjects = "" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Validar que las materias recibidas concuerden con las del usuario
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool ValidateReinscription(string data)
        {
            return false;
        }

    }
}