using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using SIIE.Models;
using SIIE.Controllers.Helpers;
using Newtonsoft.Json;
using SIIE.Controllers.Engine;
using static SIIE.Models.UserModels;

namespace SIIE.Controllers
{
    [RoutePrefix("Users")]
    public class UserController : Controller
    {
        private StudentEngine SEngine;
        private AdminEngine AEngine;

        // GET: User
        [Route("")]
        [SessionAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Obtener informacion de usuario actual
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Data")]
        [SessionAuthorize]
        public JsonResult Get()
        {
            SEngine = new StudentEngine(Convert.ToInt32(Session["controlNumber"]));
            var Data =SEngine.UserData();
            var json = JsonConvert.SerializeObject(Data);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtener informacion de usuario por ControlNumber
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Data/{controlNumber:int}")]
        [SessionAuthorize(Users ="1,2")]
        public JsonResult Get(int controlNumber)
        {
            SEngine = new StudentEngine(controlNumber);
            var data = SEngine.UserData();
            return Json(new { data=data, success = true, status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

        [Route("Search")]
        [SessionAuthorize(Users = "1,2")]
        public ActionResult Search()
        {
            return View();
        }

        /// <summary>
        /// Obtener todos los usuarios que cumplan con los filtros indicados
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Search")]
        [SessionAuthorize(Users = "1,2")]
        public JsonResult Search(UserData filters)
        {
            AEngine = new AdminEngine();
            var resultsJson = AEngine.SearchStudent(filters);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Crear usuario
        /// </summary>
        /// <param name="UserData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [SessionAuthorize(Users ="1")]
        public JsonResult Post(UserData UserData)
        {
            if(Session["userType"].ToString()=="1")
            {
                return Json(new { success=true, status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { status = HttpStatusCode.Unauthorized }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Modificar usuario
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        [Route("")]
        [SessionAuthorize(Users ="3")]
        public JsonResult Patch(UserData Data)
        {
            SEngine = new StudentEngine(Convert.ToInt32(Session["controlNumber"]));
            var status = SEngine.Update(Data);
            return Json(new { success = true,status=HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Eliminar usuario
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [SessionAuthorize(Users ="1")]
        public JsonResult Delete(UserData Data)
        {
            
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}