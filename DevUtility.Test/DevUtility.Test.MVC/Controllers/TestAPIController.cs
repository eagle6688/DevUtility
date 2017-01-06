using DevUtility.Test.Model.MvcApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevUtility.Test.MVC.Controllers
{
    public class TestAPIController : ApiController
    {
        string key = "TestCache";

        public IHttpActionResult ReceiveParam(TestTable param, int index = 1)
        {
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(param));
        }

        [HttpGet]
        public IHttpActionResult SetMemoryCache()
        {
            Com.Application.Cache.MemoryCacheHelper.Set(key, "asd", 1);
            return Ok("OK");
        }

        [HttpGet]
        public IHttpActionResult TestCache()
        {
            return Ok(Com.Application.Cache.MemoryCacheHelper.Get(key));
        }
    }
}