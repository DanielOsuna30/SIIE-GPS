using SIIE.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIIE.Api
{
    [RoutePrefix("api/subject")]
    public class SubjectController : ApiController
    {

        /// <summary>
        /// Creacion de materias
        /// </summary>
        [HttpGet, Route("{subjectId:int}")]
        public HttpResponseMessage Get(int subjectId,[FromBody] CourseModels.Subject SubjectData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { User = subjectId });
        }

        /// <summary>
        /// Creacion de materias
        /// </summary>
        [HttpPost, Route("")]
        public HttpResponseMessage Post([FromBody] CourseModels.Subject SubjectData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { User = "" });
        }

        /// <summary>
        /// Modificacion de materias
        /// </summary>
        [HttpPatch, Route("{subjectId:int}")]
        public HttpResponseMessage Patch(int subjectId,[FromBody] CourseModels.Subject SubjectData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { User = "" });
        }

        /// <summary>
        /// Eliminar materias
        /// </summary>
        [HttpDelete, Route("{subjectId:int}")]
        public HttpResponseMessage Delete(int subjectId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { User = "" });
        }
    }
}
