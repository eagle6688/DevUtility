using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DevUtility.Out.Net
{
    public class BaseNetHelper
    {
        #region Variables

        protected NetworkCredential networkCredential;

        protected WebProxy webProxy;

        #endregion

        #region Constructor

        public BaseNetHelper()
            : this("anonymous", "")
        {

        }

        public BaseNetHelper(string loginName, string password)
            : this(loginName, password, null)
        {

        }

        public BaseNetHelper(string loginName, string password, WebProxy webProxy)
        {
            if (string.IsNullOrEmpty(loginName))
            {
                loginName = "anonymous";
            }

            SetCredential(loginName, password);
            this.webProxy = webProxy;
        }

        #endregion

        #region Set Credential

        protected void SetCredential(string loginName, string password)
        {
            networkCredential = new NetworkCredential(loginName, password);
        }

        #endregion
    }
}