using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIIE.Api
{
    [RoutePrefix("api/courses/")]
    public class CourseController : ApiController
    {

        

        [HttpPost, Route("/Subject/")]
        public HttpResponseMessage CreateSubject()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { User ="" });

        }
        [HttpPatch, Route("(Subject/{subjectId:int}")]
        public HttpResponseMessage PatchSubject()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { User = "" });

        }

    }
}
