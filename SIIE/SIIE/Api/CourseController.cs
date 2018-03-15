using SIIE.Api.Models;
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
        /// <summary>
        /// Crear curso
        /// </summary>
        [HttpPost, Route("")]
        public HttpResponseMessage CreateCourse()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { User = "" });
        }

        /// <summary>
        /// Crear curso
        /// </summary>
        [HttpPost, Route("")]
        public HttpResponseMessage PatchCourse()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { User = "" });
        }

        /// <summary>
        /// Crear curso
        /// </summary>
        [HttpDelete, Route("")]
        public HttpResponseMessage DeleteCourse()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { User = "" });
        }

    }
}
