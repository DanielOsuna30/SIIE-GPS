﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using SIIE.Models;
using SIIE.Controllers.Helpers;

namespace SIIE.Controllers
{
    [SessionAuthorize]
    [RoutePrefix("User")]
    public class UserController : Controller
    {
        UserModels.Admin AdminController;
        UserModels.Student StudentController;

        // GET: User
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Search")]
        public ActionResult Search()
        {
            return View();
        }

        /// <summary>
        /// Obtener informacion de usuario por ControlNumber
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public JsonResult Get(int userId = -1)
        {
            UserModels.User UserData = new UserModels.User();
            return Json(new { success = true, status=HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Crear usuario
        /// </summary>
        /// <param name="UserData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [SessionAuthorize(Users ="1")]
        public JsonResult Post(UserModels.User UserData)
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
        /// <param name="UserData"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("")]
        public JsonResult Patch(UserModels.User UserData)
        {
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Eliminar usuario
        /// </summary>
        /// <param name="UserData"></param>
        /// <returns></returns>
        [HttpDelete]
        [SessionAuthorize(Users ="1")]
        public JsonResult Delete(UserModels.User UserData)
        {
            
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtener todos los usuarios que cumplan con los filtros indicados
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Search")]
        [SessionAuthorize(Users="1,2")]
        public JsonResult GetAll(UserModels.User filters)
        {
            string filtersQuery = "Where ";
            filtersQuery += filters.Type != -1 ? "Type=" + filters.Type.ToString() : "";
            filtersQuery += filters.FirstName != null ? "FirstName='" + filters.FirstName + "'" : "";
            filtersQuery += filters.ControlNumber != 0 ? "ControlNumber=" + filters.ControlNumber : "";
            filtersQuery += filters.Semester != null ? "Semester=" + filters.Semester : "";
            filtersQuery += filters.Carrer != -1 ? "Carrer=" + filters.Carrer : "";

            List<UserModels.User> Users = new List<UserModels.User>();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}