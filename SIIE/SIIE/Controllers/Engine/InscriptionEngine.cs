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
            return true;
        }

        /// <summary>
        /// Actualizar status para inscripcion
        /// </summary>
        /// <returns></returns>
        public bool UpdateStatus(InscriptionUpdate Data)
        {
            return false;
        }

        public Carrera[] CarrerasId()
        {
            Carrera[] M = db.Carrera.ToArray();
            return M;
        }


        /// <summary>
        /// Guardar datos de inscripcion
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string Finish(InscriptionData Data)
        {
            if (ValidateData(Data))
            {
                Loginn NewLogin = new Loginn();
                NewLogin.noControl = Convert.ToString(setControlNumber(Data));
                NewLogin.Constraseña = Data.Password;
                NewLogin.Permiso = "3";

                db.Loginn.Add(NewLogin);
                db.SaveChanges();

                Alumno Alu = new Alumno
                {
                    idCarrera = Convert.ToInt32(Data.CareerOption1),
                    noControl = NewLogin.noControl,
                    Semestre = "0",

                    ApellidoP = Data.LastNameP,
                    ApellidoM = Data.LastNameM,
                    Nombre = Data.Name,
                    Sexo = Data.Gender ? "M" : "H",
                    Nacionalidad = Data.Nationality,
                    Estado = Data.State,
                    Municipio = Data.Municipality,
                    Direccion = Data.Address,
                    Colonia = Data.Suburb,
                    CP = Convert.ToString(Data.PostalCode),
                    Telefono = Data.PhoneNumber,
                    Correo = Data.Email,
                    FechaNacimiento="",
                    Preparatoria="",
                    NombrePadre="",
                    NombreMadre=""
               };
                db.Alumno.Add(Alu);
                db.SaveChanges();

                return Alu.noControl;
            }
            else
                return null;
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

            if (Data.CareerOption1 == null)
                return false;
            for (int i = 0; i > Data.CareerOption1.Length; i++)
                if (!char.IsDigit(Data.CareerOption1[i]))
                    return false;
            if (Data.Email == null)
                return false;
            return true;
        }


        public string GenerationNumber(String Egress)
        {
            String Generation = "00";
            String año = Convert.ToString(DateTime.Today.Year);
            Generation = Convert.ToString(año[2]);
            Generation = Generation + Convert.ToString(año[3]);

            return Generation;
        }

        public string AluNumber()
        {
            string Num = Convert.ToString((db.Alumno.ToArray().Count() + 1));
            return Num;
        }
        public string MaNumber()
        {
            string Num = Convert.ToString((db.Maestro.ToArray().Count() + 1));
            return Num;
        }

        public string setControlNumber(InscriptionData Data)
        {
            String ConNum;
            ConNum = Data.Level==3?Data.CareerOption1:"MA";
            ConNum += Data.Level==3? AluNumber() : MaNumber();
            return ConNum;
        }

    }
}