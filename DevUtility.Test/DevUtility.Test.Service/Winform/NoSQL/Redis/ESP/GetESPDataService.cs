using DevUtility.Test.Common.Winform;
using DevUtility.Test.RedisData.ESP;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis.ESP
{
    public class GetESPDataService : BaseAppService
    {
        RPublish_RestrictionDal rPublish_RestrictionDal;

        #region Constructor

        public GetESPDataService(string host, string password)
        {
            rPublish_RestrictionDal = new RPublish_RestrictionDal(host, password);
        }

        #endregion

        public override void Start()
        {
            DisplayMessage(rPublish_RestrictionDal.GetList().Count().ToString());
        }
    }
}