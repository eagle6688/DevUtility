using DevUtility.Test.Data.Winform.Data.Concurrency;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace DevUtility.Test.Service.Winform.Data.Concurrency
{
    public class InsertDuplicateDataService : BaseAppService
    {
        #region Variables

        string name = "";

        Timer timer = new Timer(5000);

        #endregion

        #region Constructor

        public InsertDuplicateDataService(string name)
        {
            this.name = name;
        }

        #endregion

        #region Start

        public override void Start()
        {
            //timer.Elapsed += new System.Timers.ElapsedEventHandler(TimeElapsed);
            //timer.AutoReset = true;
            //timer.Enabled = true;
            long id = TestTableDal.Instance.Add(name);
            DisplayMessage(id.ToString());
        }

        #endregion

        #region TimeElapsed

        public void TimeElapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            long id = TestTableDal.Instance.Add(name);
            DisplayMessage(id.ToString());
        }

        #endregion
    }
}