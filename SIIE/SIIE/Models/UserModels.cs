﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;


namespace SIIE.Models
{
    public class UserModels
    {
        public class UserData
        {
            public string Semester { get; set; } 
            public int Carrer { get; set; } = -1;
            public int Specialty { get; set; } = -1;
            public int Type { get; set; } = -1;
            public string FirstName { get; set; }
            public string LastNameP { get; set; }
            public string LastNameM { get; set; }
            public DateTime BirthDate { get; set; }
        }

        public class GenericUserValidator : AbstractValidator<UserData>
        {
            public GenericUserValidator()
            {
                RuleFor(x => x.FirstName).NotNull();
            }
        }

        public class Student : UserData
        {

        }
        public class Admin : UserData
        {

        }
    }
}