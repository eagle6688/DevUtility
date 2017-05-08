using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DevUtility.Out.Net.FTP
{
    #region 文件信息结构

    public struct FileStruct
    {
        public string Flags;
        public string Owner;
        public string Group;
        public bool IsDirectory;
        public DateTime CreateTime;
        public string Name;
    }

    public enum FileListStyle
    {
        UnixStyle,
        WindowsStyle,
        Unknown
    }

    #endregion

    public class clsFTP
    {
        #region 属性信息

        /// <summary>
        /// FTP请求对象
        /// </summary>
        FtpWebRequest Request = null;

        /// <summary>
        /// FTP响应对象
        /// </summary>
        FtpWebResponse Response = null;

        /// <summary>
        /// FTP服务器地址
        /// </summary>
        private Uri _Uri;

        /// <summary>
        /// FTP服务器地址
        /// </summary>
        public Uri Uri
        {
            get
            {
                if (_DirectoryPath == "/")
                {
                    return _Uri;
                }
                else
                {
                    string strUri = _Uri.ToString();
                    if (strUri.EndsWith("/"))
                    {
                        strUri = strUri.Substring(0, strUri.Length - 1);
                    }
                    return new Uri(strUri + this.DirectoryPath);
                }
            }
            set
            {
                if (value.Scheme != Uri.UriSchemeFtp)
                {
                    throw new Exception("Ftp 地址格式错误!");
                }
                _Uri = new Uri(value.GetLeftPart(UriPartial.Authority));
                _DirectoryPath = value.AbsolutePath;
                if (!_DirectoryPath.EndsWith("/"))
                {
                    _DirectoryPath += "/";
                }
            }
        }

        /// <summary>
        /// 当前工作目录
        /// </summary>
        private string _DirectoryPath;

        /// <summary>
        /// 当前工作目录
        /// </summary>
        public string DirectoryPath
        {
            get { return _DirectoryPath; }
            set { _DirectoryPath = value; }
        }

        /// <summary>
        /// FTP登录用户
        /// </summary>
        private string _UserName;

        /// <summary>
        /// FTP登录用户
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        private string _ErrorMsg;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg
        {
            get { return _ErrorMsg; }
            set { _ErrorMsg = value; }
        }

        /// <summary>
        /// FTP登录密码
        /// </summary>
        private string _Password;

        /// <summary>
        /// FTP登录密码
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        /// 连接FTP服务器的代理服务
        /// </summary>
        private WebProxy _Proxy = null;

        /// <summary>
        /// 连接FTP服务器的代理服务
        /// </summary>
        public WebProxy Proxy
        {
            get
            {
                return _Proxy;
            }
            set
            {
                _Proxy = value;
            }
        }

        /// <summary>
        /// 是否需要删除临时文件
        /// </summary>
        private bool _isDeleteTempFile = false;

        /// <summary>
        /// 异步上传所临时生成的文件
        /// </summary>
        private string _UploadTempFile = "";

        #endregion
    }
}