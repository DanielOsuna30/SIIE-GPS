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
    [SessionAuthorize(Users = "1")]
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {
        private AdminEngine AEngine = new AdminEngine();
        private InscriptionEngine IEngine = new InscriptionEngine();


        // GET: Admin
        public ActionResult Index()
        {
            Alumno[] alumno = AEngine.getAllStudents();
            return View(alumno);
        }

        [Route("Alumnos/{id:int}/Edit")]
        public ActionResult AlumnosEdit(int id)
        {
            Alumno alumno = AEngine.getStudentData(id);
            return View(alumno);
        }

        [Route("Alumnos/{id:int}/Edit")]
        [HttpPatch]
        public JsonResult AlumnosEdit(int id, InscriptionData data)
        {
            var success = AEngine.editStudentData(id, data);
            if (success)
                return Json(new { status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { status = HttpStatusCode.BadRequest }, JsonRequestBehavior.AllowGet);
        }

        [Route("Alumnos/{id:int}/Delete")]
        public ActionResult AlumnosDelete(int id)
        {
            AEngine.deleteStudent(id);
            return RedirectToAction("Index");
        }

        [Route("Create")]
        public ActionResult CreateUser()
        {
            return View(IEngine.CarrerasId());
        }

        [Route("Create")]
        [HttpPost]
        public JsonResult CreateUser(InscriptionData Data)
        {
            if (AEngine.createUser(Data))
                return Json(new { status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { status = HttpStatusCode.BadRequest }, JsonRequestBehavior.AllowGet);
        }

        [Route("Materias/Create")]
        public ActionResult CreateMateria()
        {
            return View();
        }

        [Route("Materias/Create")]
        [HttpPost]
        public JsonResult CreateMateria(Materia Data)
        {
            if (AEngine.createMateria(Data))
                return Json(new { status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { status = HttpStatusCode.BadRequest }, JsonRequestBehavior.AllowGet);
        }


        [Route("Materias")]
        public ActionResult Materias()
        {
            Materia[] materias = AEngine.getAllMaterias();
            return View(materias);
        }

        [Route("Materias/{id:int}/Edit")]
        public ActionResult MateriasEdit(int id)
        {
            Materia materia = AEngine.getMateriaData(id);
            return View(materia);
        }

        [Route("Materias/{id:int}/Edit")]
        [HttpPatch]
        public JsonResult MateriasEdit(int id, Materia data)
        {
            bool materiaEdit = AEngine.editMateriaData(id, data);
            if (materiaEdit)
                return Json(new { status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { status = HttpStatusCode.BadRequest }, JsonRequestBehavior.AllowGet);
        }

        [Route("Maestros")]
        public ActionResult Maestros()
        {
            Maestro[] maestros = AEngine.getAllTeachers();
            return View(maestros);
        }

        [Route("Maestros/{id:int}/Edit")]
        public ActionResult MaestrosEdit(int id)
        {
            Maestro maestros = AEngine.getTeacherData(id);
            return View(maestros);
        }

        [Route("Maestros/{id:int}/Edit")]
        [HttpPatch]
        public JsonResult MaestrosEdit(int id, MaestroUpdate data)
        {
            bool maestroEdit = AEngine.editTeacherData(id, data);
            if (maestroEdit)
                return Json(new { status = HttpStatusCode.OK }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { status = HttpStatusCode.BadRequest }, JsonRequestBehavior.AllowGet);
        }

    }
}