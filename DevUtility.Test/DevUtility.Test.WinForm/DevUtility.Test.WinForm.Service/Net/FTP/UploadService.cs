using DevUtility.Out.Net.FTP;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Net.FTP
{
    public class UploadService : BaseAppService
    {
        #region Variables

        string user, pwd;

        #endregion

        #region Constructor

        public UploadService(string user, string pwd)
        {
            this.user = user;
            this.pwd = pwd;
        }

        #endregion

        #region Start

        public override void Start()
        {

        }

        #endregion
    }
}