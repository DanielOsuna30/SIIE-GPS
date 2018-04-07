using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace SIIE.Models
{
    public class CourseModels
    {
        public class Carrer
        {
            public int id { get; set; }
            public string Name { get; set; }
        }

        public class Course
        {
            public int id { get; set; }
            public int CarrerId { get; set; }
            public string SubjectsJson { get; set; }
        }

        public class StudentCourse
        {
            public int id { get; set; }
            public int CarrerId { get; set; }
            public string CourseHistoryJson { get; set; }
        }

        public class Subject
        {
            public int id { get; set; }
            public string Name { get; set; }
            public int Carrer { get; set; }
            public int Credits { get; set; }
            public int Hours { get; set; }
            public int Semester { get; set; }
        }

        public class SubjectStructure
        {
            public int id { get; set; }
            public int SubjectId { get; set; }
            public string SubjectStructureJson { get; set; }
        }

        public class ActiveSubjects
        {
            public int id { get; set; }
            public int SubjectId { get; set; }
            public int CarrerId { get; set; }
            public int TeacherId { get; set; }
            public string ScheduleJson { get; set; }
        }

        public class SemesterSchedule
        {
            public int id { get; set; }
            public int StudentId { get; set; }
            public string Subjects { get; set; }
            
        }

        public class AcademicHistory
        {
            public int semester { get; set; }
            public List<Materia> Cursando { get; set; }

            public class Materia
            {
                public string name { get; set; }
                public string status { get; set; }
                public string calificacion { get; set; }
            }
        }

        public class materias
        {
            public string nombremateria { get; set; }
            public string nombremaestro { get; set; }

            public string nombresalon { get; set; }

            public List<horario> horas { get; set; }
            public class horario
            {
                public string diassem { get; set; }

                public string horainicio { get; set; }

                public string horafinal { get; set; }
            }
        }

        public class cursando
        {
            public int semestre { get; set; }
            public List<materias> materias { get; set; }
        }


    }
}