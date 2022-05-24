
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
using DataAccess.Repository;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DeadlineController : ApiController
    {
        private static string _dataSource = DataSource.Source();
        private readonly static string _uri = DataSource.dbSP();

        private readonly IAppServices _appService = new AppServices(new PostingDate(_dataSource));


         public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

         public IHttpActionResult Get(string Operate, string PositionType, string SchoolYear)
        {
            var para = new { Operate, PositionType, SchoolYear };

            var result = _appService.AppOne.CommonObject<LTODefalutDate>(Operate, para);


            return CheckGetResult(result);
        }

         public IHttpActionResult Get(string Operate, string PositionType, string SchoolYear, string PublishDate)
        {
            var para = new { Operate, PositionType, SchoolYear, PublishDate };

            var result = _appService.AppOne.CommonAction(Operate, para);


            return   CheckActionResult(result);
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
