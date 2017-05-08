using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DevUtility.Out.Net.FTP
{
    public class FTPHelper
    {
        #region Variables

        private FtpWebRequest reqFTP = null;

        private string userName { get; set; }

        private string password { get; set; }

        //private string ftpUri { get; set; }

        private NetworkCredential certficate;

        public FtpStatusCode statusCode { get; set; }

        public string statusDescription { get; set; }

        #endregion

        #region Constructor

        public FTPHelper(string ftpUserName, string ftpPassword)
        {
            this.userName = ftpUserName;
            this.password = ftpPassword;
            certficate = new NetworkCredential(ftpUserName, ftpPassword);
            //this.ftpUri = ftpUri;
        }

        #endregion

        #region UploadOverMove

        public bool UploadOverMove(string ftpRootDirectory, string sourceFilePath, string storedFilePath, string storedFileName, ref string errMessage)
        {
            FileInfo fileInfo = new FileInfo(sourceFilePath);
            Uri uri = new Uri(storedFilePath);
            string remoteDirectory = storedFilePath.Remove(0, ftpRootDirectory.Length);
            remoteDirectory = remoteDirectory.Substring(0, remoteDirectory.Length - storedFileName.Length);

            try
            {
                CreateDirectory(ftpRootDirectory, remoteDirectory);

                FtpWebRequest reqFTP = CreateFtpRequest(uri, WebRequestMethods.Ftp.UploadFile);
                reqFTP.ContentLength = fileInfo.Length;

                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;

                FileStream fs = fileInfo.OpenRead();
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);

                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                strm.Close();
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            return false;
        }

        #endregion

        #region DownloadFile

        public bool DownloadFile(string remoteFilePath, string localFilePath, ref string errMessage)
        {
            try
            {
                string localDirector = Path.GetDirectoryName(localFilePath);
                if (!Directory.Exists(localDirector))
                {
                    Directory.CreateDirectory(localDirector);
                }

                FtpWebResponse response = CreateFtpResponse(new Uri(remoteFilePath), WebRequestMethods.Ftp.DownloadFile);
                byte[] buffer = new byte[2048];
                int bytesCount = 0;
                Stream stream = response.GetResponseStream();
                using (FileStream fs = new FileStream(localFilePath, FileMode.Create))
                {
                    while ((bytesCount = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fs.Write(buffer, 0, bytesCount);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
            }
            return false;
        }

        #endregion

        #region DirectoryExist

        private bool DirectoryExist(string ftpDirectory)
        {
            List<string> list = GetDirectoryList(ftpDirectory);

            if (list != null)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Create Directory

        public void CreateDirectory(string ftpUri, string remoteDirectory)
        {
            this.statusDescription = ftpUri;
            string parentDirector = ftpUri;

            try
            {
                if (!string.IsNullOrEmpty(remoteDirectory))
                {
                    remoteDirectory = remoteDirectory.Replace("\\", "/");
                    string[] directors = remoteDirectory.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string director in directors)
                    {
                        parentDirector = string.Concat(parentDirector, director);
                        this.statusDescription = parentDirector;

                        if (!DirectoryExist(parentDirector))
                        {
                            CreateFtpResponse(new Uri(parentDirector), WebRequestMethods.Ftp.MakeDirectory);
                        }

                        parentDirector = string.Concat(parentDirector, "/");
                    }
                }
            }
            catch (WebException ex)
            {
                statusDescription = ex.Message;
                throw ex;
            }
        }

        #endregion

        #region CreateFtpWebRequest

        private FtpWebRequest CreateFtpRequest(Uri uri, string method)
        {
            reqFTP = (FtpWebRequest)WebRequest.Create(uri);
            reqFTP.Proxy = null;
            reqFTP.Credentials = new NetworkCredential(userName, password);
            reqFTP.KeepAlive = true;
            reqFTP.UseBinary = true;
            reqFTP.UsePassive = true;
            reqFTP.Method = method;
            reqFTP.UsePassive = true;
            return reqFTP;
        }

        #endregion

        #region CreateFtpResponse

        private FtpWebResponse CreateFtpResponse(Uri uri, string method)
        {
            try
            {
                FtpWebRequest request = CreateFtpRequest(uri, method);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                this.statusCode = response.StatusCode;
                this.statusDescription = response.StatusDescription;
                return response;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = ex.Response as FtpWebResponse;
                if (response != null)
                {
                    this.statusCode = response.StatusCode;
                    this.statusDescription = response.StatusDescription;
                }
                throw ex;
            }
        }

        #endregion

        #region GetDirectoryList

        private List<string> GetDirectoryList(string ftpDirectory)
        {
            List<string> ftpRawList = new List<string>();
            StringBuilder result = new StringBuilder();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftpDirectory));
            request.Timeout = 60000;
            request.ReadWriteTimeout = 60000;
            request.Credentials = this.certficate;
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Stream data = response.GetResponseStream();

                using (StreamReader reader = new StreamReader(data))
                {
                    string responseString = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    ftpRawList.AddRange(result.ToString().Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));

                    return ftpRawList;
                }
            }
        }

        #endregion
    }
}