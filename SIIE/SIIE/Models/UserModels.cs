using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;


namespace SIIE.Models
{
    public class UserModels
    {
        public class User
        {
            public int ControlNumber { get; set; }
            public string Password { get; set; }
            public string Semester { get; set; } 
            public int Carrer { get; set; } = -1;
            public int Specialty { get; set; } = -1;
            public int Type { get; set; } = -1;
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }
        }

        public class Student : User
        {
            public void Get()
            {
            }
        }
        public class Admin : User
        {
            public void Get()
            {

            }
        }

        public class TypeUsers
        {
            public int id { get; set; }
            public string Name { get; set; }
            public int PermissionsLevel { get; set; }
        }

        public class GenericUserValidator : AbstractValidator<User>
        {
            public GenericUserValidator()
            {
                RuleFor(x => x.FirstName).NotNull();
            }
        }
    }
}