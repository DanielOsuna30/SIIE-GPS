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
                Loginn NewLogin = new Loginn();
                NewLogin.noControl = Convert.ToString(setControlNumber(Data));
                NewLogin.Constraseña = Data.Password;
                NewLogin.Permiso = "3";

                db.Loginn.Add(NewLogin);
                db.SaveChanges();

                Alumno Alu = new Alumno();
                Alu.idCarrera = CarrerNumber(Data.CareerOption1);
                Alu.Cursando = "0";
                Alu.HistorialAcademico = "0";
                Alu.noControl = NewLogin.noControl;
                Alu.Semestre = "0";

                Alu.ApellidoP = Data.LastNameP;
                Alu.ApellidoM = Data.LastNameM;
                Alu.Nombre = Data.Name;
                Alu.FechaNacimiento = Data.Date;
                Alu.Sexo = Convert.ToString(Data.Gender);
                Alu.Nacionalidad = Data.Nationality;
                Alu.Preparatoria = Data.PrevSchool;
                Alu.Estado = Data.State;
                Alu.Municipio = Data.Municipality;
                Alu.Direccion = Data.Address;
                Alu.Colonia = Data.Suburb;
                Alu.CP = Convert.ToString( Data.PostalCode);
                Alu.Telefono = Data.PhoneNumber;
                Alu.Correo = Data.Email;
                Alu.NombrePadre = Data.FatherName + Data.FatherLastNameP + Data.FatherLastNameM;
                Alu.NombreMadre = Data.MotherName + Data.MotherLastNameP + Data.MotherLastNameM;
                Alu.TelefonoPadre = Data.FatherPhoneNumber;
                Alu.TelefonoMadre = Data.MotherPhoneNumber;
                Alu.OtroContacto = Data.EmergenciesName + "  " + Data.EmergenciesPhoneNumber;

         

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

        public string setControlNumber(InscriptionData Data)
        {
            String ConNum;
            ConNum = CarrerNumber(Data.CareerOption1);
            ConNum += GenerationNumber(Data.EgressDate);
            ConNum += AluNumber();

            return ConNum;
        }

    }
}