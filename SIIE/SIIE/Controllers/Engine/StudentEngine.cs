using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIIE.Models;
using Newtonsoft.Json;
using static SIIE.Models.UserModels;

namespace SIIE.Controllers.Engine
{
    public class StudentEngine
    {
        private int controlNumber;

        public StudentEngine(int cn)
        {
            controlNumber = cn;
        }

        /// <summary>
        /// Actualizar informacion de usuario logeado
        /// </summary>
        public bool Update(UserData Data)
        {
            return true;
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