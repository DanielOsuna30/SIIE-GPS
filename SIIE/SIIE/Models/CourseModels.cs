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

        public class ReinscriptionUpdate
        {
        }

        public class InscriptionData
        {
            public string LastNameP { get; set; }
            public string LastNameM { get; set; }
            public string Name { get; set; }
            public string Date { get; set; }
            public Boolean Gender { get; set; }
            public string CURP { get; set; }
            public string CareerOption1 { get; set; }
            public string CareerOption2 { get; set; }
            public string PrevSchool { get; set; }
            public string EgressDate { get; set; }
            public Double GeneralAverage { get; set; }
            public string Address { get; set; }
            public string State { get; set; }
            public string Municipality { get; set; }
            public int PostalCode { get; set; }
            public string Suburb { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string CivilStatus { get; set; }
            public Boolean Disability { get; set; }
            public Boolean Shoolarship { get; set; }
            public Boolean OpportunitiesProgram { get; set; }
            public string FatherLastNameP { get; set; }
            public string FatherLastNameM { get; set; }
            public string FatherName { get; set; }
            public string MotherLastNameP { get; set; }
            public string MotherLastNameM { get; set; }
            public string MotherName { get; set; }
            public string FatherJob { get; set; }
            public string FatherJobOther { get; set; }
            public string MotherJob { get; set; }
            public string MotherJobOther { get; set; }
            public string EconomicDependence { get; set; }
            public string HouseOwner { get; set; }
            public string IncomeRange { get; set; }
            public string EmergenciesName { get; set; }
            public string EmergenciesAdress { get; set; }
            public string EmergenciesPhoneNumber { get; set; }
            public string EmergenciesJobAdress { get; set; }
            public string EmergenciesJobPhoneNumber { get; set; }
        }

        public class InscriptionUpdate
        {
        }
    }
}