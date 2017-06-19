using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DevUtility.Test.MVC.Attributes
{
    public class AuthorityActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            HttpResponseMessage response = actionContext.Request.CreateResponse<object>(HttpStatusCode.OK, new { Message = "Hello World!" }, "application/json");
            actionContext.Response = response;
        }
    }
}