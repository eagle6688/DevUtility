using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Research.Unicode
{
    public class DollarService : BaseAppService
    {
        #region Variables

        string value = "";

        #endregion

        #region Constructor

        public DollarService(string value)
        {
            this.value = value;
        }

        #endregion

        #region Start

        public override void Start()
        {
            var str = $"\u5927\u5bb6\u597d";
            DisplayMessage(str);

            value = "\u5927\u5bb6\u597d";
            DisplayMessage($"{value}");
        }

        #endregion
    }
}