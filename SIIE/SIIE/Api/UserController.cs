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
    [Authorize]
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        [HttpGet, Route("{userId:int}")]
        public HttpResponseMessage Get(int userId)
        {
            UserModels.User UserData = new UserModels.User();
            return Request.CreateResponse(HttpStatusCode.OK, new { User = UserData });
        }

        [HttpPost, Route("")]
        public HttpResponseMessage Post([FromBody] UserModels.User UserData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Status = "Saved" });
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
            filtersQuery += filters.Type != -1 ? "Type="+filters.Type.ToString() : "";
            filtersQuery += filters.FirstName != null ? "FirstName='"+filters.FirstName+"'": "";
            filtersQuery += filters.ControlNumber != 0 ? "ControlNumber=" + filters.ControlNumber : "";
            filtersQuery += filters.Semester != null ? "Semester=" + filters.Semester : "";
            filtersQuery += filters.Carrer != -1 ? "Carrer="+filters.Carrer : "";

            List<UserModels.User> Users = new List<UserModels.User>();
            return Request.CreateResponse(HttpStatusCode.OK, new { Users = Users });
        }



        public void CreateControlNumber(UserModels.User UserData)
        {
            string controlNumber = "";
            UserData.ControlNumber = Convert.ToInt32(controlNumber);
        }

        [HttpPost, Route("{userId:int}/reinscription")]
        public HttpResponseMessage Reinscription([FromBody] UserModels.User UserData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Status = "Saved" });
        }
    }
}
