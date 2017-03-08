using DevUtility.Com.Extension.SystemExt;
using DevUtility.Com.Model;
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DevUtility.Out.Net.Http
{
    public class HttpHelper
    {
        public const int DefaultRequestTimeout = 100000;

        #region Get

        public static string Get(string url, string contentType, int timeout)
        {
            HttpWebRequest request = CreateHttpRequest(url, "GET", contentType, timeout);
            return GetResponseValue(request);
        }

        public static string Get(string url, string contentType)
        {
            return Get(url, contentType, DefaultRequestTimeout);
        }

        public static string GetText(string url)
        {
            return Get(url, "text/html");
        }

        public static string GetHttps(string url, string contentType, int timeout)
        {
            HttpWebRequest request = CreateHttpsRequest(url, "GET", contentType, timeout);
            return GetResponseValue(request);
        }

        public static string GetHttps(string url, string contentType)
        {
            return GetHttps(url, contentType, DefaultRequestTimeout);
        }

        public static string GetHttpsText(string url)
        {
            return GetHttps(url, "text/html");
        }

        #endregion

        #region Post

        public static OperationResult PostReturnResult(string url, string postData, string contentType, int timeout)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = Post(url, postData, contentType, timeout);
            }
            catch (Exception exception)
            {
                result.SetErrorMessage(exception.ToExceptionString());
            }

            return result;
        }

        public static string Post(string url, string postData, string contentType, int timeout)
        {
            HttpWebRequest request = CreateHttpRequest(url, "POST", contentType, timeout);
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            return GetResponseValue(request);
        }

        public static string PostForm(string url, string data)
        {
            return Post(url, data, "application/x-www-form-urlencoded", DefaultRequestTimeout);
        }

        public static string PostHttps(string url, string postData, string contentType, int timeout)
        {
            HttpWebRequest request = CreateHttpsRequest(url, "POST", contentType, timeout);
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            return GetResponseValue(request);
        }

        public static string PostHttpsForm(string url, string data)
        {
            return PostHttps(url, data, "application/x-www-form-urlencoded", DefaultRequestTimeout);
        }

        #endregion

        #region Init Http Request

        private static HttpWebRequest InitHttpRequest(string url, string method, string contentType, int timeout)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version11;
            request.Method = method;

            if (!string.IsNullOrEmpty(contentType))
            {
                request.ContentType = contentType;
            }
            
            request.Timeout = timeout > 0 ? timeout : DefaultRequestTimeout;
            return request;
        }

        #endregion

        #region Create request

        public static HttpWebRequest CreateHttpRequest(string url, string method, string contentType, int timeout)
        {
            if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            return InitHttpRequest(url, method, contentType, timeout);
        }

        public static HttpWebRequest CreateHttpsRequest(string url, string method, string contentType, int timeout)
        {
            if (!url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
            return InitHttpRequest(url, method, contentType, timeout);
        }

        #endregion

        #region Validate Server Certificate

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors == SslPolicyErrors.None)
                return true;

            return false;
        }

        #endregion

        #region Get response value

        public static string GetResponseValue(HttpWebRequest request)
        {
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response == null)
                {
                    return "";
                }

                Stream stream = response.GetResponseStream();

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        #endregion
    }
}