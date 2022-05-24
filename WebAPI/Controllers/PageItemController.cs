
using ClassLibrary;
using DataAccess;
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
    public class PageItemController : ApiController
    {
        private readonly string  _dataSource = DataSource.Type();
        private readonly static string _uri = DataSource.dbSP();

        static IAppServices _appService = new AppServices(DBConnection.DBSource);


        // GET: api/UserGroup
        [HttpGet]
        [Route("api/PageItem/{Operate}/{category}/{itemCode}")]
        public IHttpActionResult Get(string operate, string category, string itemcode)
        {
            var para = new { Operate = operate, Category = category, ItemCode = itemcode};


            var result = _appService.PageItem.ValueString(_dataSource, _uri, para);


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
