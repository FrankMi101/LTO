using ClassLibrary;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Web.Api.Models;

namespace Web.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InterviewSelectController : ApiController
    {
        private static string _dataSource = DataSource.currentDB();
        private readonly static string _uri = DataSource.dbSP();
        private readonly IAppServices _appService = new AppServices(new SelectCandidate(_dataSource));



        // GET: api/Deadline
        public IEnumerable<string> Get()
        {
            return new string[] { "value1 for Interview Selected", "value2 of Interview Selected" };
        }

        // GET: api/InterviewSelect/{Operate/UserID/Schoolyear/PositionID} 
        // Get All Interview selected candidate result
        public IHttpActionResult Get(string Operate, string UserID,string SchoolYear, string PositionID)
        {
            var para = new { Operate, UserID, SchoolYear , PositionID };

            var result = _appService.AppOne.CommonAction(Operate, para);

            return CheckActionResult(result);
        }

        // GET: api/InterviewSelect/{Operate/UserID/Schoolyear/PositionID} 
        // Get candidate selected or not 
        public IHttpActionResult Get(string Operate, string UserID, string SchoolYear, string PositionID,string CPNum)
        {
            var para = new { Operate, UserID, SchoolYear, PositionID,CPNum };

            var result = _appService.AppOne.CommonAction(Operate, para);

            return CheckActionResult(result);
        }

        public IHttpActionResult Post([FromBody] CandidateSelect para)
        {
            if (para.PositionID == "" || para.CPNum == "")
                return BadRequest("Invalid Check Action");

            var result = _appService.AppOne.CommonAction(para.Operate, para);

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
        private IHttpActionResult CheckGetResult(LTODefalutDate result)
        {
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }
    }
}
