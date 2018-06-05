using SIIE.Controllers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIIE.Controllers
{
    [RoutePrefix("Tutorias")]
    [SessionAuthorize]
    public class TutoriasController : Controller
    {
        // GET: Tutorias
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        //Tutores
        [Route("Tutores/Details")]
         public ActionResult TutorDetails()
        {
            return View();
        }
        
        [Route("Tutores")]
        public ActionResult ListaTutores()
        {
            return View();
        }

        //Tutorados

        [Route("Tutorados/Details")]
        public ActionResult AlumnoDetails()
        {
            return View();
        }

        [Route("Tutorados")]
        public ActionResult ListaAlumnos()
        {
            return View();
        }

        //Tutorias

        [Route("Details")]
        public ActionResult TutoriaDetails()
        {
            return View();
        }

        [Route("Create")]
        public ActionResult CrearTutoria()
        {
            return View();
        }

        [Route("List")]
        public ActionResult ListaTutorias()
        {
            return View();
        }

        [Route("Horario")]
        public ActionResult ListaHorarios()
        {
            return View();
        }

    }
}