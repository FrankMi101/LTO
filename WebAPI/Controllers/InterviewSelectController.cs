
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
    public class InterviewSelectController : ApiController
    {
        private readonly static string _dataSource = DataSource.Type();
        private readonly IAppServices _appService = new AppServices(new SelectCandidate(_dataSource));



        [HttpPost]
        [Route("api/AppRoleMatch")]
        public IHttpActionResult Post([FromBody] InterviewResult checkResult)
        {
            if (checkResult.PositionID =="" || checkResult.CPNum == "")
                return BadRequest("Invalid Check Action"); 

            var result = _appService.AppOne.CommonAction("Selected", checkResult); 

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
