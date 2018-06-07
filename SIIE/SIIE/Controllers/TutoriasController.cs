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

        [Route("Tutores/Impartiendo")]
        [SessionAuthorize(Users ="2")]
        public ActionResult ListaImpartiendo()
        {
            var tutorId = Session["controlNumber"].ToString();
            var tutorias=Engine.getTutoriasImpartidas(tutorId);
            return View(tutorias);
        }

        [Route("Tutores/Calificaciones/{idTutoria:int}")]
        [SessionAuthorize(Users = "2")]
        public ActionResult AsignarCalifaciones(int idTutoria)
        {
            var calificaciones = Engine.GetCalificaciones(idTutoria);
            return View(calificaciones);
        }

        [Route("Tutores/Calificaciones/Actualizar")]
        [SessionAuthorize(Users ="2"),HttpPost]
        public JsonResult AsignarCalificacion(int idAlumno, int idTutoria, int Calificacion)
        {
            var result = Engine.SetCalificacion(idTutoria, idAlumno, Calificacion);
            return Json(new { response = result }, JsonRequestBehavior.AllowGet);
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
            var listSalones = Engine.getSalones();
            return View(Tuple.Create(listMateria,listTutores,listSalones));
        }

        [Route("CreateTutoria"), HttpPost]
        [SessionAuthorize(Users = "1,2")]
        public JsonResult CrearTutoria(int idTutor, int idMateria, string name, string lunes, string martes, string miercoles, string jueves, string viernes)
        {
            var maestro = Session["controlNumber"].ToString();
            var response = Engine.createGroup(idTutor, idMateria, name, lunes, martes, miercoles, jueves, viernes,maestro);
            return Json(new { message = response }, JsonRequestBehavior.AllowGet);
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
            return RedirectToAction("Index","Tutorias");
        }

        [Route("Horario/{idTutoria:int}")]
        public ActionResult ListaHorarios(int idTutoria)
        {
            var list=Engine.GetHorarios(idTutoria);
            return View(list);
        }

        [Route("Delete/{idAlumno:int}/{idTutoria:int}")]
        [SessionAuthorize(Users = "1,2")]
        public ActionResult DeleteStudentFromCourse(int idAlumno, int idTutoria)
        {
            Engine.DeleteStudent(idAlumno, idTutoria);
            return RedirectToAction("ListaTutorias", "Tutorias");
        }


        [Route("Delete/{idTutoria:int}")]
        [SessionAuthorize(Users = "3")]
        public ActionResult GetOutOfCourse(int idTutoria)
        {
            var idAlumno = Engine.getIdAlumno(Session["controlNumber"].ToString());
            Engine.DeleteStudent(idAlumno, idTutoria);
            return RedirectToAction("Index", "Tutorias");
        }
    }
}