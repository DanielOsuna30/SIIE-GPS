using SIIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SIIE.Models.InscriptionModels;

namespace SIIE.Controllers.Engine
{
    public class InscriptionEngine:MainEngine
    {
        private string controlNumber;

        public InscriptionEngine()
        {

        }

        public InscriptionEngine(string controlNumber)
        {
            this.controlNumber = controlNumber;
        }

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
        public bool UpdateStatus(InscriptionUpdate Data)
        {
            return false;
        }

        /// <summary>
        /// Guardar datos de inscripcion
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public bool Finish(InscriptionData Data)
        {
            if (ValidateData(Data))
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Validar la informacion de inscripcion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool ValidateData(InscriptionData Data)
        {
            return false;
        }

    }
}