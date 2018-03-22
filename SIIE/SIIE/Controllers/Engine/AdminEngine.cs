﻿using Newtonsoft.Json;
using SIIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SIIE.Models.UserModels;

namespace SIIE.Controllers.Engine
{
    public class AdminEngine
    {
        public string SearchStudent(UserData filters)
        {
            string filtersQuery = "Where ";
            filtersQuery += filters.Type != -1 ? "Type=" + filters.Type.ToString() : "";
            filtersQuery += filters.FirstName != null ? "FirstName='" + filters.FirstName + "'" : "";
            filtersQuery += filters.ControlNumber != 0 ? "ControlNumber=" + filters.ControlNumber : "";
            filtersQuery += filters.Semester != null ? "Semester=" + filters.Semester : "";
            filtersQuery += filters.Carrer != -1 ? "Carrer=" + filters.Carrer : "";
            return "";
        }
    }
}