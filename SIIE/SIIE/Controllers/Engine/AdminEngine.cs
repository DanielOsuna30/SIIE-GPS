using Newtonsoft.Json;
using SIIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SIIE.Models.InscriptionModels;

namespace SIIE.Controllers.Engine
{
    public class AdminEngine:MainEngine
    {
        InscriptionEngine IEngine = new InscriptionEngine();
        public bool createUser(InscriptionData Data)
        {
            try
            {
                Loginn Login = new Loginn { Constraseña = Data.Password };
                if (Data.Level == 3)
                {
                    Login.Permiso = "3";
                    Login.noControl=IEngine.setControlNumber(Data);
                    db.Loginn.Add(Login);
                    db.SaveChanges();
                    Alumno New = new Alumno
                    {
                        ApellidoP = Data.LastNameP,
                        ApellidoM = Data.LastNameM,
                        Nombre = Data.Name,
                        Estado = Data.State,
                        Sexo = Data.Gender ? "M" : "H",
                        Municipio = Data.Municipality,
                        Direccion = Data.Address,
                        Colonia = Data.Suburb,
                        CP = Convert.ToString(Data.PostalCode),
                        Telefono = Data.PhoneNumber,
                        Correo = Data.Email,
                        Nacionalidad = "Mexicano",
                        FechaNacimiento = "",
                        Preparatoria = "",
                        NombrePadre = "",
                        NombreMadre = "",
                        Semestre = "0",
                        noControl=Login.noControl,
                        idCarrera=Convert.ToInt32(Data.CareerOption1)
                    };
                    db.Alumno.Add(New);
                }
                else
                {
                    Login.Permiso = "2";
                    Login.noControl = IEngine.setControlNumber(Data);
                    db.Loginn.Add(Login);
                    db.SaveChanges();
                    Maestro New= new Maestro{
                        NumEconomico=Login.noControl,
                        ApellidoP = Data.LastNameP,
                        ApellidoM = Data.LastNameM,
                        Nombre = Data.Name,
                        Estado = Data.State,
                        Sexo = Data.Gender ? "M" : "H",
                        Municipio = Data.Municipality,
                        Direccion = Data.Address,
                        Colonia = Data.Suburb,
                        CP = Convert.ToString(Data.PostalCode),
                        Telefono = Data.PhoneNumber,
                        Correo = Data.Email,
                        Nacionalidad = "Mexicano",
                        FechaNacimiento = "",
                    };
                    db.Maestro.Add(New);
                }
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool createMateria(Materia Data)
        {
            try
            {
                db.Materia.Add(Data);
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Alumno[] getAllStudents()
        {
            return db.Alumno.ToArray();
        }

        public Alumno getStudentData(int id)
        {
            return db.Alumno.FirstOrDefault(x => x.idAlumno == id);
        }

        public void deleteStudent(int id)
        {
            Alumno a = db.Alumno.FirstOrDefault(x => x.idAlumno == id);
            var cur = db.Cursando.Where(x => x.idAlumno == id);
            var hist = db.HistorialAcademico.Where(x => x.idAlumno == id);
            if (cur != null)
                db.Cursando.RemoveRange(cur);
            if (hist != null)
                db.HistorialAcademico.RemoveRange(hist);
            db.Alumno.Remove(a);
            db.SaveChanges();
        }

        public bool editStudentData(int id,InscriptionData Data)
        {
            try
            {
                var alumno = db.Alumno.FirstOrDefault(x => x.idAlumno == id);
                alumno.ApellidoP = Data.LastNameP;
                alumno.ApellidoM = Data.LastNameM;
                alumno.Nombre = Data.Name;
                alumno.Estado = Data.State;
                alumno.Municipio = Data.Municipality;
                alumno.Direccion = Data.Address;
                alumno.Colonia = Data.Suburb;
                alumno.CP = Convert.ToString(Data.PostalCode);
                alumno.Telefono = Data.PhoneNumber;
                alumno.Correo = Data.Email;

                var loginn = db.Loginn.FirstOrDefault(x => x.noControl == alumno.noControl);
                loginn.Constraseña = Data.Password;

                db.Entry(alumno).State = System.Data.Entity.EntityState.Modified;
                db.Entry(loginn).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Materia[] getAllMaterias()
        {
            return db.Materia.ToArray();
        }

        public Materia getMateriaData(int id)
        {
            return db.Materia.FirstOrDefault(x => x.idMateria == id);
        }

        public bool editMateriaData(int id,Materia data)
        {
            try
            {
                var materia = db.Materia.FirstOrDefault(x => x.idMateria == id);
                materia.NombreMateria = data.NombreMateria;
                materia.AbreviacionMateria = data.AbreviacionMateria;
                materia.Clave = data.Clave;
                materia.Creditos = data.Creditos;
                materia.HrsTeoricas = data.HrsTeoricas;
                materia.HrsPracticas = data.HrsPracticas;
                materia.PlanEstudios = data.PlanEstudios;

                db.Entry(materia).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void deleteMateria(int id)
        {
            try
            {
                Materia m = db.Materia.FirstOrDefault(x => x.idMateria == id);
                var cur = db.Cursando.Where(x => x.idMateria == id);
                var grupos = db.Grupo.Where(x => x.idMateria == id);
                var his = db.HistorialAcademico.Where(x => x.idHistorialAcademico == id);
                db.Materia.Remove(m);
                db.SaveChanges();
            }
            catch(Exception e)
            {

            }
        }

        public Maestro[] getAllTeachers()
        {
            return db.Maestro.ToArray();
        }
        
        public Maestro getTeacherData(int id)
        {
            return db.Maestro.FirstOrDefault(x => x.idMaestro == id);
        }

        public bool editTeacherData(int id,MaestroUpdate data)
        {
            try
            {
                var maestro = db.Maestro.FirstOrDefault(x => x.NumEconomico == id.ToString());
                maestro.Nombre = data.Nombre;
                maestro.ApellidoP = data.ApellidoP;
                maestro.ApellidoM = data.ApellidoM;
                maestro.Colonia = data.Colonia;
                maestro.Correo = data.Correo;
                maestro.CP = data.CP;
                maestro.Direccion = data.Direccion;
                maestro.Estado = data.Estado;
                maestro.Municipio = data.Municipio;
                maestro.Telefono = data.Telefono;

                var loginn = db.Loginn.FirstOrDefault(x => x.noControl == id.ToString());
                loginn.Constraseña = data.Password;


                db.Entry(maestro).State = System.Data.Entity.EntityState.Modified;
                db.Entry(loginn).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void deleteTeacher(int id)
        {
            try
            {
                Maestro m = db.Maestro.FirstOrDefault(x => x.idMaestro == id);
                var grupos=
                db.Maestro.Remove(m);
                db.SaveChanges();
            }
            catch(Exception e)
            {

            }
        }
    }
}