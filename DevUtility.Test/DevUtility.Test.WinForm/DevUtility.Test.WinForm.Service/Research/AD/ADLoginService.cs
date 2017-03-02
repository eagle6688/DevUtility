using DevUtility.Out.Application.Security;
using DevUtility.Win.Services.AppService;
using System;
using System.DirectoryServices;
using System.Text;

namespace DevUtility.Test.WinForm.Service.Research.AD
{
    public class ADLoginService : BaseAppService
    {
        #region Variables

        private string loginName = "";

        private string password = "";

        private string domain = "";

        #endregion

        #region Constructor

        public ADLoginService(string value)
        {
            string[] array = value.Split(',');
            this.domain = array[0];
            this.loginName = array[1];
            this.password = array[2];
        }

        #endregion

        #region Start

        public override void Start()
        {
            if (LDAPAuthenticationHelper.Authenticated(domain, loginName, password))
            {
                DisplayMessage("Yes, you are valid user.");
            }
            else
            {
                DisplayMessage("No, you are invalid user.");
            }

            LDAPUserParam param = new LDAPUserParam();
            param.Host = $"{domain}.com";
            param.Domain = domain;
            param.LoginName = loginName;
            param.Password = password;
            param.FirstNameAttribute = "givenname";
            param.LastNameAttribute = "sn";
            param.DisplayNameAttribute = "displayname";
            param.EmailAttribute = "mail";
            param.UniqueIDAttribute = "employeenumber";
            var user = LDAPAuthenticationHelper.GetUser(param);
            DisplayMessage(Newtonsoft.Json.JsonConvert.SerializeObject(user));
        }

        #endregion
    }
}