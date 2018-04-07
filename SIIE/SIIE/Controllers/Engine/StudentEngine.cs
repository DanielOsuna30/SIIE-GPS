using SIIE.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using AutoMapper;
using SIIE.Controllers.Helpers;

namespace SIIE.Controllers.Engine
{
    public class StudentEngine : MainEngine
    {
        private string controlNumber;

        public StudentEngine(int cn)
        {
            controlNumber = cn.ToString();
        }

        public object UserData()
        {
            var Data = db.Alumno.FirstOrDefault(x => x.noControl == controlNumber);
            if (Data == null)
                return db.Maestro.FirstOrDefault(x => x.idMaestro == controlNumber);
            else
                return Data;
        }

        /// <summary>
        /// Actualizar informacion de usuario
        /// </summary>
        public bool Update(UserModels.UserData Data)
        {
            Alumno A = db.Alumno.FirstOrDefault(x => x.noControl == controlNumber);
            int aluNum = db.Alumno.ToArray().Count();
            if (A != null)
            {
                //A = MapperEngine.convertAlumno(Data, A);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }


        /// <summary>
        /// Dar de baja alumno
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            try
            {
                var a = db.Alumno.FirstOrDefault(x => x.noControl == controlNumber);
                db.Alumno.Remove(a);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Obtener horario de semestre actual
        /// </summary>
        /// <returns></returns>
        public string getSchedule()
        {
            var sem = db.Alumno.First(x => x.noControl == controlNumber);
            var mat = db.Cursando.Where(x => x.idAlumno == sem.idAlumno && x.Semestre == sem.Semestre).ToArray();
            var cur = new CourseModels.cursando();
            foreach (var materias in mat)
            {
                var m = new CourseModels.materias();
                m.nombremateria = db.Materia.First(x => x.idMateria == materias.idMateria).NombreMateria;
                var idmaestro = db.Grupo.First(x => x.idGrupo == materias.idGrupo).idMaestro;
                m.nombremaestro = db.Maestro.First(x => x.idMaestro == idmaestro).Nombre;
                var idgrupo = db.Grupo.First(x => x.idGrupo == materias.idGrupo).idSalon;
                m.nombresalon = db.Salon.First(x => x.idSalon == idgrupo).NombreSalon;

                var idhorario = db.HorarioGrupo.First(x => x.idGrupo == materias.idGrupo).idHorario;
                var horarios = db.Horario.Where(x => x.idHorario == idhorario).ToArray();
                foreach (var n in horarios)
                {
                    var hora = new CourseModels.materias.horario();
                    hora.diassem = n.DiaSemana;
                    hora.horainicio = n.HrInicio;
                    hora.horafinal = n.HrFin;
                    m.horas.Add(hora);
                }

                cur.materias.Add(m);
            }
            return JsonConvert.SerializeObject(cur);
        }

        /// <summary>
        /// Obtener historial academico
        /// </summary>
        /// <returns></returns>
        public string getAcademicHistory()
        {
            var HistorialAcad = db.HistorialAcademico.Where(x => x.idAlumno == controlNumber).ToArray();
            var result = new CourseModels.AcademicHistory();
            result.semester = Convert.ToInt32(HistorialAcad.First().Semestre);
            foreach (var materia in HistorialAcad)
            {
                var m = new CourseModels.AcademicHistory.Materia();
                m.name = db.Materia.First(x => x.idMateria == materia.idMateria).NombreMateria;
                m.status = Convert.ToString(materia.Estado);
                m.calificacion = materia.Calificacion;

                result.Cursando.Add(m);
            }
            return JsonConvert.SerializeObject(result);
        }

        public string getDashboardData()
        {
            return "";
        }
    }
}