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
        {
            SetCredential(loginName, password);
            base.webProxy = webProxy;
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

        #region Download

        /// <summary>
        /// Download a file from ftpPath to path.
        /// </summary>
        /// <param name="ftpPath"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public void Download(string ftpPath, string path)
        {
            Download(ftpPath, path, true);
        }

        /// <summary>
        /// Download a file from ftpPath to path.
        /// </summary>
        /// <param name="ftpPath"></param>
        /// <param name="path"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public void Download(string ftpPath, string path, bool overwrite)
        {
            InitDirAndFile(path, overwrite);
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
            DownloadAsync(ftpPath, path, true);
        }

        public void DownloadAsync(string ftpPath, string path, bool overwrite)
        {
            InitDirAndFile(path, overwrite);

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

        #region Init directory and file

        private void InitDirAndFile(string path, bool overwrite)
        {
            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                Directory.CreateDirectory(fileInfo.DirectoryName);
                return;
            }

            if (overwrite)
            {
                File.Delete(path);
                return;
            }

            throw new Exception("File already exists in local machine.");
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

        #region Upload

        public void Upload(string path, string ftpPath)
        {
            Upload(path, ftpPath, true);
        }

        public void Upload(string path, string ftpPath, bool overwrite)
        {
            UploadValidate(path, ftpPath, overwrite);

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
            UploadValidate(path, ftpPath, overwrite);

            using (WebClient webClient = webClientHelper.Create())
            {
                webClient.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressChanged);
                webClient.UploadFileCompleted += new UploadFileCompletedEventHandler(UploadFileCompleted);
                webClient.UploadFileAsync(new Uri(ftpPath), path);
            }
        }

        private void UploadValidate(string path, string ftpPath, bool overwrite)
        {
            if (!File.Exists(path))
            {
                throw new Exception("File does not exist.");
            }

            if (!overwrite && Exists(ftpPath))
            {
                throw new Exception("File already exists in Ftp.");
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

        #region Get File Information

        public FtpFileInfo GetFileInfo(string ftpPath)
        {
            var list = GetFileInfoList(ftpPath);
            return list.Count == 0 ? null : list[0];
        }

        public List<FtpFileInfo> GetFileInfoList(string ftpPath)
        {
            List<FtpFileInfo> list = new List<FtpFileInfo>();
            List<string> details = ListDetails(ftpPath);

            foreach (string detail in details)
            {
                var fileInfo = GetFileInfoByDetail(detail);
                list.Add(fileInfo);
            }

            return list;
        }

        #endregion

        #region Get File Information by detail

        private FtpFileInfo GetFileInfoByDetail(string detail)
        {
            FtpOSTypes osType = FtpOSTypesHelper.GetFtpOSType(detail);

            switch (osType)
            {
                case FtpOSTypes.Unix:
                    return GetUnixFileInfoByDetail(detail);

                case FtpOSTypes.Windows:
                    return GetWindowsFileInfoByDetail(detail);

                default:
                    return null;
            }
        }

        private FtpFileInfo GetUnixFileInfoByDetail(string detail)
        {
            List<string> detailInfo = detail.SplitStringWithMultiSameChar(' ');

            if (detailInfo.Count != 9)
            {
                return null;
            }

            FtpFileInfo ftpileInfo = new FtpFileInfo();
            ftpileInfo.UnixAuthority = detailInfo[0];
            ftpileInfo.Type = FtpFileTypesHelper.GetUnixFileType(detailInfo[2]);
            ftpileInfo.Size = long.Parse(detailInfo[4]);
            ftpileInfo.Name = detailInfo[8];
            return ftpileInfo;
        }

        private FtpFileInfo GetWindowsFileInfoByDetail(string detail)
        {
            List<string> detailInfo = detail.SplitStringWithMultiSameChar(' ');

            if (detailInfo.Count != 4)
            {
                return null;
            }

            FtpFileInfo ftpileInfo = new FtpFileInfo();
            ftpileInfo.Name = detailInfo[3];

            if (detailInfo[2] == "<DIR>")
            {
                ftpileInfo.Type = FtpFileTypes.Directory;
            }
            else
            {
                long size = 0;

                if (long.TryParse(detailInfo[2], out size))
                {
                    ftpileInfo.Size = size;
                    ftpileInfo.Type = FtpFileTypes.File;
                }
                else
                {
                    ftpileInfo.Type = FtpFileTypes.Unknow;
                }
            }

            return ftpileInfo;
        }

        #endregion

        #region Delete

        public void Delete(string ftpPath)
        {
            GetResponse(ftpPath, WebRequestMethods.Ftp.DeleteFile);
        }

        #endregion
    }
}