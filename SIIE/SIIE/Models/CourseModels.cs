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

        public class ReinscriptionData
        {
            public string BeginDate { get; set; }
            public string EndingDate { get; set; }
            public double Quantity1 { get; set; }
            public double Quantity2 { get; set; }
        }

        public class InscriptionData
        {
        }
    }
}