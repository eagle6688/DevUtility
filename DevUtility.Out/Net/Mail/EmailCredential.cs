using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Net.Mail
{
    public class EmailCredential
    {
        public int SmtpPort { set; get; }

        public string SmtpServer { set; get; }

        public string LoginName { set; get; }

        public string Password { set; get; }
    }
}