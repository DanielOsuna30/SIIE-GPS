using SIIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIIE.Controllers.Engine
{
    public class InscriptionEngine
    {
        /// <summary>
        /// Revisar si ya es fecha de inscripcion
        /// </summary>
        /// <returns></returns>
        public bool GetStatus()
        {
            return false;
        }

        /// <summary>
        /// Actualizar status para inscripcion
        /// </summary>
        /// <returns></returns>
        public bool UpdateStatus(CourseModels.InscriptionUpdate Data)
        {
            return false;
        }

        /// <summary>
        /// Validar la informacion de inscripcion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Validate(CourseModels.InscriptionData Data)
        {
            return false;
        }
    }
}