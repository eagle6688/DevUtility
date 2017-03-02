using DevUtility.Com.Model;
using System;
using System.DirectoryServices;
using System.Text;

namespace DevUtility.Out.Application.Security
{
    public class LDAPAuthenticationHelper
    {
        #region Is Authenticated

        public static bool Authenticated(string domain, string loginName, string password)
        {
            string host = $"{domain}.com";
            return IsAuthenticated(host, domain, loginName, password).IsSucceeded;
        }

        public static bool Authenticated(string host, string domain, string loginName, string password)
        {
            return IsAuthenticated(host, domain, loginName, password).IsSucceeded;
        }

        public static OperationResult IsAuthenticated(string host, string domain, string loginName, string password)
        {
            string path = $"LDAP://{host}";
            string domainLoginName = $"{domain}\\{loginName}";
            return IsAuthenticated(path, domainLoginName, password);
        }

        public static OperationResult IsAuthenticated(string path, string domainLoginName, string password)
        {
            OperationResult result = new OperationResult();
            DirectoryEntry directoryEntry = new DirectoryEntry(path, domainLoginName, password, AuthenticationTypes.Secure);

            try
            {
                object obj = directoryEntry.NativeObject;
            }
            catch (Exception ex)
            {
                result.SetErrorMessage(ex.Message);
            }

            return result;
        }

        #endregion

        #region Get User

        public static LDAPUser GetUser(LDAPUserParam param)
        {
            LDAPUser user = new LDAPUser();
            DirectoryEntry directoryEntry = new DirectoryEntry(param.Path, param.DomainLoginName, param.Password, AuthenticationTypes.Secure);

            try
            {
                DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
                directorySearcher.Filter = param.UserNameFilter;

                SearchResult searchResult = directorySearcher.FindOne();
                DirectoryEntry userDirectoryEntry = searchResult.GetDirectoryEntry();
                PropertyCollection propertyCollection = userDirectoryEntry.Properties;
                SetUser(param, propertyCollection, ref user);
            }
            catch (Exception exception)
            {
                user.SetErrorMessage(exception.Message);
            }

            return user;
        }

        #endregion

        #region Set User

        private static void SetUser(LDAPUserParam param, PropertyCollection propertyCollection, ref LDAPUser user)
        {
            user.ID = GetPropertyValue(param.UniqueIDAttribute, propertyCollection);
            user.FirstName = GetPropertyValue(param.FirstNameAttribute, propertyCollection);
            user.LastName = GetPropertyValue(param.LastNameAttribute, propertyCollection);
            user.DisplayName = GetPropertyValue(param.DisplayNameAttribute, propertyCollection);
            user.Email = GetPropertyValue(param.EmailAttribute, propertyCollection);
        }

        private static string GetPropertyValue(string name, PropertyCollection propertyCollection)
        {
            if (propertyCollection.Contains(name))
            {
                PropertyValueCollection propertyValueCollection = propertyCollection[name];

                if (propertyValueCollection.Count > 0)
                {
                    return propertyValueCollection[0].ToString();
                }
            }

            return string.Empty;
        }

        #endregion
    }
}