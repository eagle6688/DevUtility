using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Application.Security
{
    public class LDAPUserParam
    {
        public string Host { set; get; }

        public string Path
        {
            get
            {
                return $"LDAP://{Host}";
            }
        }

        public string Domain { set; get; }

        public string LoginName { set; get; }

        public string DomainLoginName
        {
            get
            {
                return $"{Domain}\\{LoginName}";
            }
        }

        public string Password { set; get; }

        public string UserNameAttribute = "SAMAccountName";

        public string UserNameFilter
        {
            get
            {
                if (string.IsNullOrEmpty(UserNameAttribute)
                    || string.IsNullOrEmpty(LoginName))
                {
                    return string.Empty;
                }

                return $"({UserNameAttribute}={LoginName})";
            }
        }

        public string UserObjectClass { set; get; }

        public string UserObjectFilter { set; get; }

        public string RDNAttribute { set; get; }

        public string UniqueIDAttribute { set; get; }

        public string FirstNameAttribute { set; get; }

        public string LastNameAttribute { set; get; }

        public string DisplayNameAttribute { set; get; }

        public string EmailAttribute { set; get; }
    }
}