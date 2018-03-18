using SIIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIIE.Controllers.Engine
{
    public class ReinscriptionEngine
    {
        /// <summary>
        /// Revisar si ya es fecha de reinscripcion
        /// </summary>
        /// <returns></returns>
        public bool GetStatus()
        {
            return false;
        }

        /// <summary>
        /// Actualizar status para reinscripcion
        /// </summary>
        /// <returns></returns>
        public bool UpdateStatus(CourseModels.ReinscriptionUpdate Data)
        {
            return false;
        }

        /// <summary>
        /// Validar que las materias recibidas concuerden con las del usuario
        /// </summary>
        /// <returns></returns>
        public bool Validate(CourseModels.ReinscriptionStudentData Data)
        {
            return false;
        }
    }
}