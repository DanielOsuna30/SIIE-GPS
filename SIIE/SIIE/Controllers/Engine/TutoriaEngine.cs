using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIIE.Models;


namespace SIIE.Controllers.Engine
{
    public class TutoriaEngine:MainEngine
    {
        public List<Tutorias> getTutorias()
        {
            return db.Tutorias.ToList();
        }

        public List<Tutores> getTutores()
        {
            return db.Tutores.ToList();
        }

        public List<Alumno> getTutorados()
        {
            return db.Alumno.Where(x => x.AlumnosTutoriaRelationship.Count != 0).ToList();
        }

        public List<Materia> getMaterias()
        {
            return db.Materia.ToList();
        }

        public List<AlumnosTutoriaRelationship> getTutoriaCursando(int i)
        {
            var list= db.Tutorias.FirstOrDefault(x => x.Id == i).AlumnosTutoriaRelationship.ToList();
            if (list.Count == 0)
            {
                list = new List<AlumnosTutoriaRelationship>();
                list.Add(new AlumnosTutoriaRelationship
                {
                    IdAlumno = -1,
                    IdTutoria = i,
                    Tutorias = db.Tutorias.FirstOrDefault(x => x.Id == i)
                });
            }
            return list;
        }

        public List<AlumnosTutoriaRelationship> getTutoradoCursando(int id)
        {
            return db.AlumnosTutoriaRelationship.Where(x => x.IdAlumno == id).ToList();
        }

        public List<Tutorias> getTutoriasImpartidas(int id)
        {
            return db.Tutorias.Where(x => x.TutorId == id).ToList();
        }

        public List<Tutorias> getRecomendaciones(int id)
        {
            var materias = db.Alumno.FirstOrDefault(x => x.idAlumno == id).Cursando.ToList().OrderBy(x=>x.idMateria);
            List<Tutorias> materia = new List<Tutorias>();
            foreach (Cursando m in materias)
            {
                List<Tutorias> curso = db.Tutorias.Where(x => x.MateriaId == m.idMateria && (db.AlumnosTutoriaRelationship.FirstOrDefault(y => y.IdAlumno == id && y.IdTutoria == x.Id) == null)).ToList();
                if (curso.Count != 0)
                    materia.AddRange(curso);
            }
            return materia;
        }

        public void Inscribirse(int id, string noControl)
        {
            var idAlumno = db.Alumno.FirstOrDefault(x => x.noControl == noControl).idAlumno;
            if(db.AlumnosTutoriaRelationship.FirstOrDefault(x=>x.IdAlumno==idAlumno && x.IdTutoria==id)==null)
            {
                AlumnosTutoriaRelationship Inscripcion = new AlumnosTutoriaRelationship { IdTutoria = id, IdAlumno = idAlumno, Calificacion = 0 };
                db.AlumnosTutoriaRelationship.Add(Inscripcion);
                db.SaveChanges();
            }
        }

        public int getIdAlumno(string noControl)
        {
            return db.Alumno.FirstOrDefault(x => x.noControl == noControl).idAlumno;
        }

        public List<Salon> getSalones()
        {
            return db.Salon.ToList();
        }

        public  List<AlumnosTutoriaRelationship> tutoriasCursandoAlumno(string v)
        {
            int id = db.Alumno.FirstOrDefault(x => x.noControl == v).idAlumno;
            var list = db.AlumnosTutoriaRelationship.Where(x => x.IdAlumno == id).ToList();
            return list;
        }

        public string createGroup(int idTutor,int idMateria, string name,string lunes, string martes, string miercoles, string jueves, string viernes)
        {
            var group = new Tutorias { MateriaId = idMateria, TutorId = idTutor, Name = name };
            if (db.Tutorias.FirstOrDefault(x => x.MateriaId == idMateria && x.TutorId == idTutor) == null)
            {
                db.Tutorias.Add(group);
                db.SaveChanges();
                List<HorarioTutorias> hor = new List<HorarioTutorias>();
                if (lunes != "")
                {
                    var horario = lunes.Split('-');
                    HorarioTutorias Lunes = new HorarioTutorias { TutoriaId = group.Id, Dia = "Lunes", Entrada = horario[0], Salida = horario[1], IdSalon = Convert.ToInt32(horario[2]) };
                    hor.Add(Lunes);
                }
                if (martes != "")
                {
                    var horario = martes.Split('-');
                    HorarioTutorias Lunes = new HorarioTutorias { TutoriaId = group.Id, Dia = "Martes", Entrada = horario[0], Salida = horario[1], IdSalon = Convert.ToInt32(horario[2]) };
                    hor.Add(Lunes);
                }
                if (miercoles != "")
                {
                    var horario = miercoles.Split('-');
                    HorarioTutorias Lunes = new HorarioTutorias { TutoriaId = group.Id, Dia = "Miercoles", Entrada = horario[0], Salida = horario[1], IdSalon = Convert.ToInt32(horario[2]) };
                    hor.Add(Lunes);
                }
                if (jueves != "")
                {
                    var horario = jueves.Split('-');
                    HorarioTutorias Lunes = new HorarioTutorias { TutoriaId = group.Id, Dia = "Jueves", Entrada = horario[0], Salida = horario[1], IdSalon = Convert.ToInt32(horario[2]) };
                    hor.Add(Lunes);
                }
                if (viernes != "")
                {
                    var horario = viernes.Split('-');
                    HorarioTutorias Lunes = new HorarioTutorias { TutoriaId = group.Id, Dia = "Viernes", Entrada = horario[0], Salida = horario[1], IdSalon = Convert.ToInt32(horario[2]) };
                    hor.Add(Lunes);
                }
                db.HorarioTutorias.AddRange(hor);
                db.SaveChanges();
                return "Grupo guardado";
            }
            else
            {
                return "Ya existe un grupo asi";
            }
        }

        public void DeleteStudent(int idAlumno, int idTutoria)
        {
            var Record = db.AlumnosTutoriaRelationship.FirstOrDefault(x => x.IdAlumno == idAlumno && x.IdTutoria == idTutoria);
            if (Record != null)
            {
                db.AlumnosTutoriaRelationship.Remove(Record);
                db.SaveChanges();
            }
        }

        public List<HorarioTutorias> GetHorarios(int idTutoria)
        {
            return db.HorarioTutorias.Where(x => x.TutoriaId == idTutoria).ToList();
        }
    }
}