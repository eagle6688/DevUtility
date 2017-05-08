using DevUtility.Out.Net.FTP;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Net.FTP
{
    public class ListDirectoryService : BaseAppService
    {
        #region Variables

        string url, user, pwd;

        #endregion

        #region Constructor

        public ListDirectoryService(string url, string user, string pwd)
        {
            this.url = url;
            this.user = user;
            this.pwd = pwd;
        }

        #endregion

        #region Start

        public override void Start()
        {
            FtpHelper ftpHelperForWindows = new FtpHelper();

            foreach (string line in ftpHelperForWindows.List("ftp://10.100.97.145:2101/"))
            {
                DisplayMessage(line);
            }

            foreach (string line in ftpHelperForWindows.List("ftp://10.100.97.145:2101/CentOS-7-x86_64-DVD-1611.iso"))
            {
                DisplayMessage(line);
            }

            FtpHelper ftpHelperForUnix = new FtpHelper(user, pwd);

            foreach (string line in ftpHelperForUnix.List(url))
            {
                DisplayMessage(line);
            }
        }

        #endregion
    }
}