
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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InterviewOutComeController : ApiController
    {
        private readonly static string _dataSource = DataSource.Type();
        static IAppServices _action = new AppServices(DBConnection.DBSource, new InterviewResults());

        [HttpPost]
        [Route("api/InterviewOutCome")]
        public IHttpActionResult Post([FromBody] InterviewResult checkResult)
        {
            if (checkResult.PositionID == "" || checkResult.CPNum == "")
                return BadRequest("Invalid Check Action"); // return Request.CreateResponse(HttpStatusCode.BadRequest, "Group ID Can not be blank");

            var result = _action.AppOne.CommonAction("OutCome", checkResult);

            return CheckActionResult(result);

        }
        private IHttpActionResult CheckActionResult(string result)
        {
            if (result == "Failed")
                return new ReturnMessage(result, Request);
            else
                return Ok(result);
        }
       
    }
}
