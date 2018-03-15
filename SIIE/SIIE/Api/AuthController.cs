using SIIE.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIIE.Api
{
    [RoutePrefix("api/login")]
    public class AuthController : ApiController
    {
        [HttpPost,Route("")]
        public HttpResponseMessage login([FromBody] UserModels.User Data)
        {
            String ControlNum = Data.ControlNumber.ToString(), Password = Data.Password;
            return Request.CreateResponse(HttpStatusCode.OK, new { Status = "Logged" });
        }
    }
}
