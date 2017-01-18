using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.WinForm.Service.Database.DBHelper.BigDataHelper
{
    public class InsertListService : BaseAppService
    {
        public override void Start()
        {
            var list = new List<ChinaSupport_PushRecord>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(new ChinaSupport_PushRecord()
                {
                    ID = i + 1,
                    ItemID = Guid.NewGuid(),
                    DataType = 1,
                    Status = 0,
                    CreateTime = DateTime.Now,
                    LastUpdate = DateTime.Now
                });
            }

            string testDBConn = Common.Winform.AppConfigHelper.TestDBConn;
            DevUtility.Com.Database.DBHelper.BigDataHelper bigDataHelper = new DevUtility.Com.Database.DBHelper.BigDataHelper(testDBConn);

            if (bigDataHelper.Insert<ChinaSupport_PushRecord>("ChinaSupport_PushRecord", list, new List<string>() { "ID" }))
            {
                DisplayMessage("Success!");
            }
        }
    }

    class ChinaSupport_PushRecord
    {
        public long ID { set; get; }

        public Guid ItemID { set; get; }

        public int DataType { set; get; }

        public int Status { set; get; }

        public DateTime CreateTime { set; get; }

        public DateTime LastUpdate { set; get; }
    }
}