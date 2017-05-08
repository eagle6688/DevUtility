using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Net
{
    public class UriService : BaseAppService
    {
        #region Start

        public override void Start()
        {
            Uri uri = new Uri("ftp://127.0.0.1/asd/qwe");
            DisplayMessage(uri.Scheme);
            DisplayMessage(uri.AbsolutePath);
            DisplayMessage(uri.AbsoluteUri);
            DisplayMessage(uri.GetLeftPart(UriPartial.Authority));
        }

        #endregion
    }
}