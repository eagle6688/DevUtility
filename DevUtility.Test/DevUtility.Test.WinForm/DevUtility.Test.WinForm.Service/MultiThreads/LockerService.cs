using DevUtility.Com.Base;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.MultiThreads
{
    public class LockerService : BaseAppService
    {
        #region Variables

        int index = -1;

        #endregion

        #region Constructor

        public LockerService(int index)
        {
            this.index = index;
        }

        #endregion

        #region Start

        public override void Start()
        {
            string locker = LockerHelper.Instance.GetLocker("asd");

            lock (locker)
            {
                DisplayMessage(string.Format("Excute index {0}...", index));
                Thread.Sleep(3000);
            }
        }

        #endregion
    }
}