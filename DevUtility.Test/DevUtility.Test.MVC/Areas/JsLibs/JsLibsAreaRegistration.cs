using System.Web.Mvc;

namespace DevUtility.Test.MVC.Areas.JsLibs
{
    public class JsLibsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "JsLibs";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "JsLibs_default",
                "JsLibs/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}