﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIIE.Controllers.Helpers;


namespace SIIE.Controllers
{
    [SessionAuthorize]
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            return View();
        }
    }
}