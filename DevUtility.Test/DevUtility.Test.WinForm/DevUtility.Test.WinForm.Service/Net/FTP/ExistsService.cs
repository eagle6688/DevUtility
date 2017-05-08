using DevUtility.Out.Net.FTP;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Net.FTP
{
    public class ExistsService : BaseAppService
    {
        #region Start

        public override void Start()
        {
            FtpHelper ftpHelperForWindows = new FtpHelper();
            DisplayMessage(ftpHelperForWindows.Exists("ftp://10.100.97.145:2101/CentOS-7-x86_64-DVD-1611.iso") ? "Exist" : "Not found!");
            DisplayMessage(ftpHelperForWindows.Exists("ftp://10.100.97.145:2101/asd.txt") ? "Exist" : "Not found!");
        }

        #endregion
    }
}