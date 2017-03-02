using DevUtility.Com.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Application.Security
{
    public class LDAPUser : OperationResult
    {
        public string ID { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string DisplayName { set; get; }

        public string Email { set; get; }
    }
}