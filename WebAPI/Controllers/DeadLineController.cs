
using ClassLibrary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models; 
using DataAccess;

namespace WebAPI.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DeadLineController : ApiController
    {
        private   static string _dataSource = DataSource.Source();
        private readonly static string _uri = DataSource.dbSP();

        static IAppServices _action = new AppServices(DBConnection.DBSource); 
 
 
        [HttpGet]
        [Route("api/DeadLineDate/{SchoolYear}/{PublishDate}/{PositionType}")]
        public IHttpActionResult Get(string schoolyear, string publishDate, string positionType)
        {
            var para = new { SchoolYear = schoolyear, PublishDate = publishDate, PositionType = positionType };
 

            var result = _action.AppDeadLine.ValueString(_dataSource, _uri, para);


            return CheckActionResult(result);
        }
 
        private IHttpActionResult CheckActionResult(string result)
        {
            if (result == "Failed")
                return new ReturnMessage(result, Request);
            else
                return Ok(result);
        }
        private HttpResponseMessage CheckResultMessage(HttpStatusCode statusCode, string message)
        {
            return Request.CreateResponse(statusCode, message);
        }
    }
}
