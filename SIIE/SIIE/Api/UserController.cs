using Newtonsoft.Json.Linq;
using SIIE.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIIE.Api
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        [HttpGet, Route("{userId:int}")]
        public HttpResponseMessage Get(int userId)
        {
            UserModels.User UserData = new UserModels.User();
            return Request.CreateResponse(HttpStatusCode.OK, new { User = UserData });
        }

        [HttpPatch, Route("{userId:int}")]
        public HttpResponseMessage Patch([FromBody] UserModels.User UserData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Status = "Saved" });
        }

        [HttpDelete, Route("{userId:int}")]
        public HttpResponseMessage Delete([FromBody] UserModels.User UserData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Status = "Deleted" });
        }

        [HttpGet, Route("get")]
        public HttpResponseMessage GetAll([FromBody] UserModels.User filters)
        {
            string filtersQuery = "Where ";
            filtersQuery += filters.Type != -1 ? "" : "";
            filtersQuery += filters.FirstName != null ? "" : "";
            filtersQuery += filters.ControlNumber != 0 ? "" : "";
            filtersQuery += filters.Semester != null ? "" : "";
            filtersQuery += filters.Carrer != -1 ? "" : "";

            List<UserModels.User> Users = new List<UserModels.User>();
            return Request.CreateResponse(HttpStatusCode.OK, new { Users = Users });
        }

        [HttpPost, Route("create")]
        public HttpResponseMessage Create([FromBody] UserModels.User UserData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Status = "Saved" });
        }

        public void CreateControlNumber(UserModels.User UserData)
        {
            string controlNumber = "";
            UserData.ControlNumber = Convert.ToInt32(controlNumber);
        } 
    }
}
