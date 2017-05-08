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

        #region Set Credential

        public void SetCredential(string loginName, string password)
        {
            networkCredential = new NetworkCredential(loginName, password);
        }

        #endregion
    }
}