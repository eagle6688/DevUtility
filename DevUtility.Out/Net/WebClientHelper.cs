using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DevUtility.Out.Net
{
    public class WebClientHelper : BaseNetHelper
    {
        #region Constructor

        public WebClientHelper()
        {

        }

        public WebClientHelper(string loginName, string password)
            : this(loginName, password, null)
        {

        }

        public WebClientHelper(string loginName, string password, WebProxy webProxy)
        {
            SetCredential(loginName, password);
            base.webProxy = webProxy;
        }

        #endregion

        #region Create

        public WebClient Create()
        {
            WebClient webClient = new WebClient();

            if (networkCredential != null)
            {
                webClient.Credentials = networkCredential;
            }

            if (webProxy != null)
            {
                webClient.Proxy = webProxy;
            }

            return webClient;
        }

        #endregion
    }
}