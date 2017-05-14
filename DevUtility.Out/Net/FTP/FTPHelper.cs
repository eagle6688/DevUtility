using DevUtility.Com.Extension.SystemExt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DevUtility.Out.Net.FTP
{
    public class FtpHelper : BaseNetHelper
    {
        #region Variables

        WebClientHelper webClientHelper;

        #endregion

        #region Porperties

        public int BufferSize = 2048;

        public DownloadProgressChanged DownloadProgressChangedEvent { set; get; }

        public DownloadCompleted DownloadCompletedEvent { set; get; }

        public UploadProgressChanged UploadProgressChangedEvent { set; get; }

        public UploadFileCompleted UploadFileCompletedEvent { set; get; }

        #endregion

        #region Constructor

        public FtpHelper()
            : this("anonymous", "")
        {

        }

        public FtpHelper(string loginName, string password)
            : this(loginName, password, null)
        {

        }

        public FtpHelper(string loginName, string password, WebProxy webProxy)
            : base(loginName, password, webProxy)
        {
            webClientHelper = new WebClientHelper(loginName, password, webProxy);
        }

        #endregion

        #region Create Request

        public FtpWebRequest CreateRequest(string url, string method)
        {
            NetUri netUri = NetUri.Create(url);

            if (!netUri.IsValidProtocol)
            {
                throw new Exception("Invalid protocol.");
            }

            FtpWebRequest ftpWebRequest = FtpWebRequest.Create(url) as FtpWebRequest;
            ftpWebRequest.UseBinary = true;
            ftpWebRequest.Method = method;
            ftpWebRequest.Credentials = networkCredential;

            if (webProxy != null)
            {
                ftpWebRequest.Proxy = webProxy;
            }

            return ftpWebRequest;
        }

        #endregion

        #region Get Response

        public FtpWebResponse GetResponse(string url, string method)
        {
            FtpWebRequest request = CreateRequest(url, method);
            FtpWebResponse response = request.GetResponse() as FtpWebResponse;
            return response;
        }

        #endregion

        #region Close Response

        public void CloseResponse(ref FtpWebResponse response)
        {
            try
            {
                response.Close();
            }
            catch { }
        }

        #endregion

        #region Exists

        public bool Exists(string ftpPath)
        {
            try
            {
                var list = List(ftpPath);
                return list.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region List

        public List<string> List(string ftpPath)
        {
            List<string> list = new List<string>();
            FtpWebResponse response = GetResponse(ftpPath, WebRequestMethods.Ftp.ListDirectory);

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                string line = "";

                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            CloseResponse(ref response);
            return list;
        }

        public List<string> ListDetails(string ftpPath)
        {
            List<string> list = new List<string>();
            FtpWebRequest request = CreateRequest(ftpPath, WebRequestMethods.Ftp.ListDirectoryDetails);
            FtpWebResponse response = request.GetResponse() as FtpWebResponse;

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                string line = "";

                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            CloseResponse(ref response);
            return list;
        }

        #endregion

        #region Upload

        public void Upload(string path, string ftpPath)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                FtpWebRequest request = CreateRequest(ftpPath, WebRequestMethods.Ftp.UploadFile);

                using (Stream stream = request.GetRequestStream())
                {
                    int readBytesCount = 0;
                    byte[] buffer = new byte[BufferSize];

                    while ((readBytesCount = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, readBytesCount);
                    }
                }
            }
        }

        public void UploadAsync(string path, string ftpPath)
        {
            UploadAsync(path, ftpPath, true);
        }

        public void UploadAsync(string path, string ftpPath, bool overwrite)
        {
            using (WebClient webClient = webClientHelper.Create())
            {
                webClient.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressChanged);
                webClient.UploadFileCompleted += new UploadFileCompletedEventHandler(UploadFileCompleted);
                webClient.UploadFileAsync(new Uri(ftpPath), path);
            }
        }

        #endregion

        #region Upload Events

        private void UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            UploadProgressChangedEvent?.Invoke(sender, e);
        }

        private void UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            UploadFileCompletedEvent?.Invoke(sender, e);
        }

        #endregion

        #region Download

        /// <summary>
        /// Download a file from ftpPath to path.
        /// </summary>
        /// <param name="ftpPath"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public void Download(string ftpPath, string path)
        {
            FtpWebResponse response = GetResponse(ftpPath, WebRequestMethods.Ftp.DownloadFile);

            using (Stream stream = response.GetResponseStream())
            {
                int readBytesCount = 0;
                byte[] buffer = new byte[BufferSize];

                using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    while ((readBytesCount = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, readBytesCount);
                    }
                }
            }

            CloseResponse(ref response);
        }

        public void DownloadAsync(string ftpPath, string path)
        {
            using (WebClient webClient = webClientHelper.Create())
            {
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
                webClient.DownloadFileAsync(new Uri(ftpPath), path);
            }
        }

        #endregion

        #region Download Events

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgressChangedEvent?.Invoke(sender, e);
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadCompletedEvent?.Invoke(sender, e);
        }

        #endregion

        #region Get Item Information

        /// <summary>
        /// Can be used for get file and directory item information.
        /// </summary>
        /// <param name="ftpPath"></param>
        /// <returns></returns>
        public FtpItemInfo GetItemInfo(string ftpPath)
        {
            string value = ftpPath.TrimEnd('/');
            string parent = FtpCommon.GetParent(value);
            var list = GetDirectoryItems(parent);
            return list.FirstOrDefault(q => q.FtpPath == value);
        }

        /// <summary>
        /// Only can be used for file path.
        /// </summary>
        /// <param name="ftpPath"></param>
        /// <returns></returns>
        public FtpItemInfo GetFileInfo(string ftpPath)
        {
            List<string> details = ListDetails(ftpPath);

            if (details.Count == 0 || details.Count > 1)
            {
                return null;
            }

            var fileInfo = GetItemInfoByDetail(details[0]);

            if (fileInfo != null)
            {
                fileInfo.FtpPath = ftpPath;
            }

            return fileInfo;
        }

        /// <summary>
        /// Only can be used for directory path, this method will return files and sub-directories that contained in ftpPath.
        /// </summary>
        /// <param name="ftpPath"></param>
        /// <returns></returns>
        public List<FtpItemInfo> GetDirectoryItems(string ftpPath)
        {
            List<FtpItemInfo> list = new List<FtpItemInfo>();
            List<string> details = ListDetails(ftpPath);

            foreach (string detail in details)
            {
                var fileInfo = GetItemInfoByDetail(detail);

                if (fileInfo == null)
                {
                    continue;
                }

                fileInfo.FtpPath = FtpCommon.AppendPath(ftpPath, fileInfo.Name);
                list.Add(fileInfo);
            }

            return list;
        }

        #endregion

        #region Get Item Information by detail

        private FtpItemInfo GetItemInfoByDetail(string detail)
        {
            FtpOSTypes osType = FtpOSTypesHelper.GetFtpOSType(detail);

            switch (osType)
            {
                case FtpOSTypes.Unix:
                    return GetUnixItemInfoByDetail(detail);

                case FtpOSTypes.Windows:
                    return GetWindowsItemInfoByDetail(detail);

                default:
                    return null;
            }
        }

        private FtpItemInfo GetUnixItemInfoByDetail(string detail)
        {
            List<string> detailInfo = detail.Substring(0, 56).SplitStringWithMultiSameChar(' ');
            detailInfo.Add(detail.Substring(56).Trim());

            if (detailInfo.Count != 9)
            {
                return null;
            }

            FtpItemInfo ftpileInfo = new FtpItemInfo();
            ftpileInfo.UnixAuthority = detailInfo[0];
            ftpileInfo.Type = FtpItemTypesHelper.GetUnixItemType(detailInfo[0].Substring(0, 1));
            ftpileInfo.Size = long.Parse(detailInfo[4]);
            ftpileInfo.Name = detailInfo[8];
            return ftpileInfo;
        }

        private FtpItemInfo GetWindowsItemInfoByDetail(string detail)
        {
            List<string> detailInfo = detail.Substring(0, 39).SplitStringWithMultiSameChar(' ');
            detailInfo.Add(detail.Substring(39).Trim());

            if (detailInfo.Count != 4)
            {
                return null;
            }

            FtpItemInfo ftpileInfo = new FtpItemInfo();
            ftpileInfo.Name = detailInfo[3];

            if (detailInfo[2] == "<DIR>")
            {
                ftpileInfo.Type = FtpItemTypes.Directory;
            }
            else
            {
                long size = 0;
                ftpileInfo.Type = FtpItemTypes.File;

                if (long.TryParse(detailInfo[2], out size))
                {
                    ftpileInfo.Size = size;
                }
            }

            return ftpileInfo;
        }

        #endregion

        #region Delete

        public void DeleteFile(string ftpPath)
        {
            FtpWebResponse response = GetResponse(ftpPath, WebRequestMethods.Ftp.DeleteFile);
            CloseResponse(ref response);
        }

        public void DeleteDirectory(string ftpPath)
        {
            FtpWebResponse response = GetResponse(ftpPath, WebRequestMethods.Ftp.RemoveDirectory);
            CloseResponse(ref response);
        }

        #endregion

        #region Rename

        public void Rename(string ftpPath, string newName)
        {
            FtpWebRequest request = CreateRequest(ftpPath, WebRequestMethods.Ftp.Rename);
            request.RenameTo = newName;
            FtpWebResponse response = request.GetResponse() as FtpWebResponse;
            CloseResponse(ref response);
        }

        #endregion

        #region Create Directory

        public void CreateDirectory(string ftpPath)
        {
            FtpWebResponse response = GetResponse(ftpPath, WebRequestMethods.Ftp.MakeDirectory);
            CloseResponse(ref response);
        }

        #endregion
    }
}