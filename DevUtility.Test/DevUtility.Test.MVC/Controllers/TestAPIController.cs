using DevUtility.Test.Model.MvcApp;
using DevUtility.Test.MVC.Attributes;
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
        //Get: api/TestAPI/

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

        [HttpGet]
        [AuthorityAction]
        public IHttpActionResult AuthorityAction()
        {
            return Ok(new { QWE = "asd" });
        }

        #region Dic

        [HttpGet]
        public IHttpActionResult Dic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("a", "asd");
            dic.Add("b", "qwe");
            return Json(dic);
        }

        #endregion
    }
}