using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIIE.Api
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        [HttpPost, Route("subject")]
        public HttpResponseMessage CreateSubject()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { User ="" });

        }

        [HttpPatch, Route("subject/{subjectId:int}")]
        public HttpResponseMessage PatchSubject()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { User = "" });
        }
    }
}
