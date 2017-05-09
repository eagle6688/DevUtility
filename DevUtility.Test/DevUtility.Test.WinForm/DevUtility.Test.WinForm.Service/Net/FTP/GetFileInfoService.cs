using DevUtility.Out.Net.FTP;
using DevUtility.Win.Services.AppService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Net.FTP
{
    public class GetFileInfoService : BaseAppService
    {
        #region Variables

        string url, user, pwd;

        #endregion

        #region Constructor

        public GetFileInfoService(string url, string user, string pwd)
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
            var fileInfo1 = ftpHelperForWindows.GetFileInfo("ftp://10.100.97.145:2101/VisualStudio2017_ProductLaunchPoster-1.png");
            DisplayMessage(JsonConvert.SerializeObject(fileInfo1));

            FtpHelper ftpHelperForUnix = new FtpHelper(user, pwd);
            var fileInfo2 = ftpHelperForUnix.GetFileInfo(url);
            DisplayMessage(JsonConvert.SerializeObject(fileInfo2));
        }

        #endregion
    }
}