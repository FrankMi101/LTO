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
    public class DeadlineController : ApiController
    {
        private static string _dataSource = DataSource.currentDB();
        private readonly static string _uri = DataSource.dbSP();
        private readonly IAppServices _appService = new AppServices(new PostingDate(_dataSource));


        // GET: api/Deadline
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Deadline/5
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/Deadline/5
         public IHttpActionResult  Get(string Operate, string PositionType, string SchoolYear)
        {
            var para = new { Operate, PositionType, SchoolYear };

            var result = _appService.AppOne.CommonObject<LTODefalutDate>(Operate, para);

            return   CheckGetResult(result);
        }

         public IHttpActionResult Get(string Operate, string PositionType, string SchoolYear,string PublishDate)
        {
            var para = new { Operate, PositionType, SchoolYear ,PublishDate};

            var result = _appService.AppOne.CommonAction(Operate, para);

            return CheckActionResult(result);
        }
 
        // POST: api/Deadline
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Deadline/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Deadline/5
        public void Delete(int id)
        {
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
