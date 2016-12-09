using DevUtility.Com.Application.Log;
using DevUtility.Com.Extension.SystemExt;
using DevUtility.Com.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DevUtility.Out.Net.Http
{
    public class HttpHelper
    {
        #region Get

        public static string Get(string url)
        {
            return Get(url, "application/x-www-form-urlencoded");
        }

        public static string Get(string url, string contentType)
        {
            return Get(url, contentType, 100000);
        }

        public static string Get(string url, string contentType, int timeout)
        {
            HttpWebRequest request = CreateBaseHttpRequest(url, "GET", contentType, timeout);
            return GetResponseValue(request);
        }

        public static string GetHttps(string url)
        {
            HttpWebRequest request = CreateBaseHttpsRequest(url, "GET", "application/x-www-form-urlencoded");
            return GetResponseValue(request);
        }

        #endregion

        #region Post

        public static string Post(string url, string postData, int timeout = 100000)
        {
            var result = PostAndGetResult(url, postData, "application/x-www-form-urlencoded", timeout);
            return result.Data != null ? result.Data.ToString() : "";
        }

        public static OperationResult PostAndGetResult(string url, string postData, int timeout = 100000)
        {
            return PostAndGetResult(url, postData, "application/x-www-form-urlencoded", timeout); ;
        }

        public static string Post(string url, string postData, string contentType, int timeout = 100000)
        {
            var result = PostAndGetResult(url, postData, contentType, timeout);
            return result.Data != null ? result.Data.ToString() : "";
        }

        public static OperationResult PostAndGetResult(string url, string postData, string contentType, int timeout = 100000)
        {
            OperationResult result = new OperationResult();
            HttpWebRequest request;

            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                request = CreateBaseHttpsRequest(url, "POST", contentType, timeout);
            }
            else
            {
                request = CreateBaseHttpRequest(url, "POST", contentType, timeout);
            }

            byte[] data = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = data.Length;

            try
            {
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception exception)
            {
                LogHelper.Error(exception);
                result.SetErrorMessage(exception.ToExceptionContent().ToString());
                return result;
            }

            result.Data = GetResponseValue(request);
            return result;
        }

        #endregion

        #region Create request

        public static HttpWebRequest CreateBaseHttpsRequest(string url, string method, string contentType, int timeout = 100000)
        {
            if (!url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
            return GetBaseHttpRequest(url, method, contentType, timeout);
        }

        public static HttpWebRequest CreateBaseHttpRequest(string url, string method, string contentType, int timeout = 100000)
        {
            if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            return GetBaseHttpRequest(url, method, contentType, timeout);
        }

        public static HttpWebRequest GetBaseHttpRequest(string url, string method, string contentType, int timeout = 100000)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version11;
            request.Method = method;
            request.ContentType = contentType;
            request.Timeout = timeout;
            return request;
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

        #region Get response

        public static HttpWebResponse GetResponse(HttpWebRequest request)
        {
            HttpWebResponse response = null;

            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (Exception exception)
            {
                DevUtility.Com.Application.Log.LogHelper.Error(exception);
            }

            return response;
        }

        #endregion

        #region Get response value

        public static string GetResponseValue(HttpWebRequest request)
        {
            using (HttpWebResponse response = GetResponse(request))
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

        #region Create http request

        public static HttpWebRequest CreateHttpRequest(string url, string method, Encoding encoding, string postData = "")
        {
            HttpWebRequest request = null;

            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                //对服务端证书进行有效性校验（非第三方权威机构颁发的证书，如自己生成的，不进行验证，这里返回true）
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }

            request.Method = method;

            if (method.ToLower() == "post")
            {
                byte[] data = encoding.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            return request;
        }

        public static HttpWebRequest CreateHttpFileRequest(string url, Encoding encoding, string contentType = "", string postData = "")
        {
            HttpWebRequest request = null;

            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                //对服务端证书进行有效性校验（非第三方权威机构颁发的证书，如自己生成的，不进行验证，这里返回true）
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }

            if (string.IsNullOrWhiteSpace(contentType))
            {
                contentType = "application/x-www-form-urlencoded";
            }

            byte[] data = encoding.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            return request;
        }

        #endregion
    }
}