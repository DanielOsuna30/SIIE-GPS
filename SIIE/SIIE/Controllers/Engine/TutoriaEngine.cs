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
            return db.Tutorias.FirstOrDefault(x => x.Id == i).AlumnosTutoriaRelationship.ToList();
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
                Tutorias curso = db.Tutorias.FirstOrDefault(x => x.MateriaId == m.idMateria);
                if (curso != null)
                    materia.Add(curso);
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

        public  List<AlumnosTutoriaRelationship> tutoriasCursandoAlumno(string v)
        {
            int id = db.Alumno.FirstOrDefault(x => x.noControl == v).idAlumno;
            var list = db.AlumnosTutoriaRelationship.Where(x => x.IdAlumno == id).ToList();
            return list;
        }

        public string createGroup(int idTutor,int idMateria, string name)
        {
            var group = new Tutorias { MateriaId = idMateria, TutorId = idTutor, Name = name };
            if (db.Tutorias.FirstOrDefault(x => x.MateriaId == idMateria && x.TutorId == idTutor) == null)
            {
                db.Tutorias.Add(group);
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
    }
}