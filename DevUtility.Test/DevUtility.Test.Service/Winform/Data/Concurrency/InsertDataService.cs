using DevUtility.Test.Data.Winform.Data.Concurrency;
using DevUtility.Test.Model.Winform.Data.Concurrency;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace DevUtility.Test.Service.Winform.Data.Concurrency
{
    public class InsertDataService : BaseAppService
    {
        #region Variables

        Timer timer = new Timer(5000);

        #endregion

        #region Start

        public override void Start()
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimeElapsed); 
            timer.AutoReset = true;  
            timer.Enabled = true;
        }

        #endregion

        #region TimeElapsed

        public void TimeElapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            TestTable entity = new TestTable();
            entity.Name = "qwe";
            entity.ID = TestTableDal.Instance.Add(entity);
            DisplayMessage(entity.ID.ToString());
        }

        #endregion
    }
}