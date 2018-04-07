using SIIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SIIE.Models.InscriptionModels;

namespace SIIE.Controllers.Engine
{
    public class InscriptionEngine : MainEngine
    {
        private string controlNumber;

        public InscriptionEngine()
        {

        }

        public string CarrerNumber(String Car)
        {
            string Carrer = "000";
            Carrer = db.Carrera.FirstOrDefault(x => x.NombreCarrera == Car).idCarrera;
            return Carrer;
        }

        public string GenerationNumber(String Egress)
        {
            String Generation = "00";
            String año = Convert.ToString(DateTime.Today.Year);
            Generation = Convert.ToString(año[2]);
            Generation = Generation + Convert.ToString(año[3]);

            return Generation;
        }

        public String AluNumber()
        {
            String Num = "000";
            Num = Convert.ToString((db.Alumno.ToArray().Count() + 1));
            return Num;
        }

        public int ControlNumber(InscriptionData Data)
        {
            String ConNum;
            ConNum = CarrerNumber(Data.CareerOption1);
            ConNum = ConNum + GenerationNumber(Data.EgressDate);
            ConNum = ConNum + AluNumber();

            return Convert.ToInt16(ConNum);
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
            if (Data.LastNameP == null)
                return false;
            for (int i = 0; i > Data.LastNameP.Length; i++)
                if (!char.IsDigit(Data.LastNameP[i]))
                    return false;
            if (Data.LastNameM == null)
                return false;
            for (int i = 0; i > Data.LastNameM.Length; i++)
                if (!char.IsDigit(Data.LastNameM[i]))
                    return false;
            if (Data.Name == null)
                return false;
            for (int i = 0; i > Data.Name.Length; i++)
                if (!char.IsDigit(Data.Name[i]))
                    return false;
            if (Data.Date == null)
                return false;
            if (Data.CURP == null)
                return false;
            if (Data.CareerOption1 == null)
                return false;
            for (int i = 0; i > Data.CareerOption1.Length; i++)
                if (!char.IsDigit(Data.CareerOption1[i]))
                    return false;
            if (Data.CareerOption2 == null)
                return false;
            for (int i = 0; i > Data.CareerOption2.Length; i++)
                if (!char.IsDigit(Data.CareerOption2[i]))
                    return false;
            if (Data.PrevSchool == null)
                return false;

            if (Data.EgressDate == null)
                return false;
            if (Data.Email == null)
                return false;
            return true;
        }

    }
}