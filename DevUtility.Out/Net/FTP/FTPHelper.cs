﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace DevUtility.Out.Net.FTP
{
    public class FtpHelper : BaseNetHelper, IDisposable
    {
        #region Variables

        WebClientHelper webClientHelper;

        #endregion

        #region Porperties

        public event DownloadProgressChanged DownloadProgressChangedEvent;

        public event DownloadDataCompleted DownloadDataCompletedEvent;

        public event UploadProgressChanged UploadProgressChangedEvent;

        public event UploadFileCompleted UploadFileCompletedEvent;

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
            FtpWebRequest request = CreateRequest(ftpPath, WebRequestMethods.Ftp.DownloadFile);
            FtpWebResponse response = request.GetResponse() as FtpWebResponse;

            using (Stream stream = response.GetResponseStream())
            {
                int readBytesCount = 0;
                byte[] buffer = new byte[1024];

                using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    while ((readBytesCount = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, readBytesCount);
                    }
                }
            }
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
                webClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(DownloadFileCompleted);
                webClient.DownloadFileAsync(new Uri(ftpPath), path);
            }
        }

        #endregion

        #region Download Events

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgressChangedEvent?.Invoke(sender, e);
        }

        private void DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            DownloadDataCompletedEvent?.Invoke(sender, e);
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

            return list;
        }

        #endregion

        #region Get Ftp OS Type

        public static FtpOSTypes GetFtpOSType(string detail)
        {
            if (IsUnixDetail(detail))
            {
                return FtpOSTypes.Unix;
            }

            if (IsWindowsDetail(detail))
            {
                return FtpOSTypes.Windows;
            }

            return FtpOSTypes.Unknown;
        }

        #endregion

        #region Is Unix Detail

        public static bool IsUnixDetail(string value)
        {
            if (value.Length < 10)
            {
                return false;
            }

            string str = value.Substring(0, 8);
            return Regex.IsMatch(str, "(-|d)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)(-|r)(-|w)(-|x)");
        }

        #endregion

        #region Is Windows Detail

        public static bool IsWindowsDetail(string value)
        {
            if (value.Length < 8)
            {
                return false;
            }

            string str = value.Substring(0, 8);
            return Regex.IsMatch(str, "[0-9][0-9]-[0-9][0-9]-[0-9][0-9]");
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}