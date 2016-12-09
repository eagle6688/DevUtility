using DevUtility.Out.Net.Http;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.Net.Http
{
    public class TestHttpHelperUsingService : BaseAppService
    {
        string url = "";

        public TestHttpHelperUsingService(string url)
        {
            this.url = url;
        }

        public override void Start()
        {
            HttpHelper.GetHttps(url);
        }
    }
}