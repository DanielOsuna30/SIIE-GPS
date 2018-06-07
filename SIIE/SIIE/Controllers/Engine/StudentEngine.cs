using SIIE.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using AutoMapper;
using SIIE.Controllers.Helpers;
using System.Collections.Generic;

namespace SIIE.Controllers.Engine
{
    public class StudentEngine : MainEngine
    {
        private string controlNumber;

        public StudentEngine(string cn)
        {
            controlNumber = cn;
        }

        public Alumno UserData()
        {
            var Data = db.Alumno.FirstOrDefault(x => x.noControl == controlNumber);
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
        public CourseModels.cursando getSchedule()
        {
            var sem = db.Alumno.First(x => x.noControl == controlNumber);
            var mat = db.Cursando.Where(x => x.idAlumno == sem.idAlumno && x.Semestre == sem.Semestre).ToArray();
            var cur = new CourseModels.cursando { semestre = Convert.ToInt32(sem.Semestre) };
            foreach (var materias in mat)
            {
                var m = new CourseModels.materias();
                m.nombremateria = db.Materia.First(x => x.idMateria == materias.idMateria).NombreMateria;
                var idmaestro = db.Grupo.First(x => x.idGrupo == materias.idGrupo).idMaestro;
                var maestro = db.Maestro.First(x => x.idMaestro == idmaestro);
                m.nombremaestro = maestro.Nombre + " " + maestro.ApellidoP;
                var idgrupo = db.Grupo.First(x => x.idGrupo == materias.idGrupo).idSalon;
                m.nombresalon = db.Salon.First(x => x.idSalon == idgrupo).NombreSalon;

                var idhorario = db.HorarioGrupo.First(x => x.idGrupo == materias.idGrupo).idHorario;
                var horarios = db.Horario.Where(x => x.idHorario == idhorario).ToArray();
                foreach (var n in horarios)
                {
                    var hora = new CourseModels.materias.horario();
                    hora.diassem = n.DiaSemana;
                    hora.hora = n.HrInicio+"-"+n.HrFin;
                    m.horas.Add(hora);
                }

                cur.materias.Add(m);
            }
            return cur;
        }

        /// <summary>
        /// Obtener historial academico
        /// </summary>
        /// <returns></returns>
        public CourseModels.AcademicHistory getAcademicHistory()
        {
            
            int controlN = Convert.ToInt32(controlNumber);
            var HistorialAcad = db.HistorialAcademico.Where(x => x.idAlumno == controlN).ToArray();
            var result = new CourseModels.AcademicHistory();
            var alumno = db.Alumno.FirstOrDefault(x => x.noControl == controlNumber);
            result.carrera =alumno.Carrera.NombreCarrera;
            result.nombreAlumno = alumno.Nombre +" "+ alumno.ApellidoP;
            foreach (var materia in HistorialAcad)
            {
                var m = new CourseModels.AcademicHistory.Materia();
                var Materia = db.Materia.First(x => x.idMateria == materia.idMateria);
                m.name = Materia.NombreMateria;
                m.semestre = Materia.Semestre;
                m.status = materia.Estado.ToString();
                m.calificacion = materia.Calificacion.ToString();

                result.historial.Add(m);
            }
            return result;
        }


        public string getDashboardData()
        {
            return "";
        }
    }
}