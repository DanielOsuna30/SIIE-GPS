using SIIE.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using AutoMapper;
using SIIE.Controllers.Helpers;

namespace SIIE.Controllers.Engine
{
    public class StudentEngine:MainEngine
    {
        private string controlNumber;
        private ModelsMapper MapperEngine = new ModelsMapper();
        
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
                A = MapperEngine.convertAlumno(Data, A);
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
            catch(Exception e)
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
            CourseModels.SemesterSchedule SemesterSchedule= new CourseModels.SemesterSchedule();
            var a= JsonConvert.SerializeObject(SemesterSchedule);
            return a.ToString();
        }

        /// <summary>
        /// Obtener historial academico
        /// </summary>
        /// <returns></returns>
        public string getAcademicHistory()
        {
            CourseModels.AcademicHistory SemesterSchedule = new CourseModels.AcademicHistory();
            var a = JsonConvert.SerializeObject(SemesterSchedule);
            return a.ToString();
        }

        public string getDashboardData()
        {
            return "";
        }
    }
}