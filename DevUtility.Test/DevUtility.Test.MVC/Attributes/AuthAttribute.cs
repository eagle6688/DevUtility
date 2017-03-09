using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DevUtility.Test.MVC.Attributes
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public bool IsAuth { set; get; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!IsAuth)
            {
                ContentResult Content = new ContentResult();
                Content.Content = string.Format("<script type='text/javascript'>alert('请先登录！');window.location.href='{0}';</script>", FormsAuthentication.LoginUrl);
                filterContext.Result = Content;
                //filterContext.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}