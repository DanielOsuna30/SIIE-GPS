using SIIE.Controllers.Engine;
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
        TutoriaEngine Engine = new TutoriaEngine();

        // GET: Tutorias
        [Route("")]
        [SessionAuthorize(Users = "3")]
        public ActionResult Index()
        {
            var listCursando = Engine.tutoriasCursandoAlumno(Convert.ToString(Session["controlNumber"]));
            return View(listCursando);
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
            var listTutores = Engine.getTutores();
            return View(listTutores);
        }

        [Route("Tutores/Imparte/{id:int}")]
        public ActionResult ListaTutoriasImpartidas(int id)
        {
            var listTutorias = Engine.getTutoriasImpartidas(id);
            return View(listTutorias);
        }

        //Tutorados

        [Route("Tutorados/Details")]
        public ActionResult AlumnoDetails()
        {
            return View();
        }

        [Route("Tutorados")]
        [SessionAuthorize(Users ="1,2")]
        public ActionResult ListaAlumnos()
        {
            var listTutorados = Engine.getTutorados();
            return View(listTutorados);
        }

        [Route("Tutorados/Cursando/{id:int}")]
        [SessionAuthorize(Users = "1,2")]
        public ActionResult ListaCursandoTutorado(int id )
        {
            var lis = Engine.getTutoradoCursando(id);
            return View(lis);
        }

        [Route("Tutorados/Recomendaciones/{id:int}")]
        [SessionAuthorize(Users ="1,2")]
        public ActionResult ListaRecomendaciones(int id)
        {
            var lis = Engine.getRecomendaciones(id);
            return View(lis);
        }

        [Route("Tutorados/Recomendaciones")]
        [SessionAuthorize(Users ="3")]
        public ActionResult ListaRecomendacionesPersonal()
        {
            var id = Engine.getIdAlumno(Session["controlNumber"].ToString());
            var lis = Engine.getRecomendaciones(id);
            return View(lis);
        }

        //Tutorias

        [Route("Details")]
        public ActionResult TutoriaDetails()
        {
            return View();
        }

        [Route("Create")]
        [SessionAuthorize(Users = "1,2")]
        public ActionResult CrearTutoria()
        {
            var listMateria = Engine.getMaterias();
            var listTutores = Engine.getTutores();
            return View(Tuple.Create(listMateria,listTutores));
        }

        [Route("CreateTutoria"),HttpPost]
        [SessionAuthorize(Users = "1,2")]
        public JsonResult CrearTutoria(int idTutor, int idMateria, string name)
        {
            var response=Engine.createGroup(idTutor,idMateria,name);
            return Json(new { message = response },JsonRequestBehavior.AllowGet);
        }

        [Route("List")]
        public ActionResult ListaTutorias()
        {
            var listTutorias = Engine.getTutorias();
            return View(listTutorias);
        }

        [Route("Cursando/{id:int}")]
        public ActionResult CursandoTutoria(int id)
        {
            var listCursando = Engine.getTutoriaCursando(id);
            return View(listCursando);
        }

        [Route("Inscribirse/{id:int}")]
        [SessionAuthorize(Users = "3")]
        public ActionResult Inscribirse(int id)
        {
            Engine.Inscribirse(id, Convert.ToString(Session["controlNumber"]));
            return RedirectToAction("Index");
        }

        [Route("Horario")]
        public ActionResult ListaHorarios()
        {
            return View();
        }

        [Route("Delete/{idAlumno:int}/{idMateria:int}")]
        [SessionAuthorize(Users = "1,2")]
        public ActionResult DeleteStudentFromCourse(int idAlumno, int idMateria)
        {
            Engine.DeleteStudent(idAlumno, idMateria);
            return RedirectToAction("Index");
        }


    }
}