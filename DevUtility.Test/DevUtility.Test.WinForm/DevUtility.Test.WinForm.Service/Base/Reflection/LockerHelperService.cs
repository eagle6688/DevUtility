using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Base.Reflection
{
    public class LockerHelperService : BaseAppService
    {
        #region Start

        public override void Start()
        {
            DisplayMessage(Com.Base.LockerHelper.Instance.GetLocker<Model.Com.Student>("test"));
        }

        #endregion
    }
}