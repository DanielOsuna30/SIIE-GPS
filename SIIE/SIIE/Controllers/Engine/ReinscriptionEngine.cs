using SIIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SIIE.Models.ReinscriptionModels;

namespace SIIE.Controllers.Engine
{
    public class ReinscriptionEngine
    {
        private int controlNumber;

        public ReinscriptionEngine()
        {

        }

        public ReinscriptionEngine(int controlNumber)
        {
            this.controlNumber = controlNumber;
        }

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
        public bool UpdateStatus(ReinscriptionUpdate Data)
        {
            return false;
        }

        /// <summary>
        /// Guardar datos de reinscripcion
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public bool Finish(ReinscriptionData Data)
        {
            if (ValidateData(Data))
            {
                return true;
            }
            else
            return false;
        }
        
        /// <summary>
        /// Validar que las materias recibidas concuerden con las del usuario
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(ReinscriptionData Data)
        {
            return false;
        }

    }
}