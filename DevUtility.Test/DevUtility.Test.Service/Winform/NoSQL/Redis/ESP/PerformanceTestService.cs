using DevUtility.Com.Extension.SystemExt;
using DevUtility.Out.NoSQL.Redis;
using DevUtility.Out.NoSQL.Redis.ModelHelper;
using DevUtility.Test.Common.Winform;
using DevUtility.Test.Model.ESP;
using DevUtility.Win.Services.AppService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis.ESP
{
    public class PerformanceTestService : BaseAppService
    {
        #region Variables

        RedisHelper redisHelper;

        RedisRowHelper<RPublish_Relation> redisRowHelper;

        RedisMultiKeysInSetHelper<RPublish_Relation> redisMultiKeysInSetHelper;

        RedisTableHelper<RPublish_Relation> redisTableHelper;

        #endregion

        #region Constructor

        public PerformanceTestService(string host, string password)
        {
            var dataConfig = RedisConfigHelper.DefaultRedisConfig;
            dataConfig.Host = host;
            dataConfig.Password = password;

            redisHelper = new RedisHelper(dataConfig);
            redisRowHelper = new RedisRowHelper<RPublish_Relation>(dataConfig);
            redisMultiKeysInSetHelper = new RedisMultiKeysInSetHelper<RPublish_Relation>(dataConfig);
            redisTableHelper = new RedisTableHelper<RPublish_Relation>(dataConfig);
        }

        #endregion

        #region Start

        public override void Start()
        {
            DisplayMessage(DateTime.Now.ToLongDateTimeString());
            RedisTableHelper_GetList();

            var model = new RPublish_Relation()
            {
                RelationType = "SUP"
            };

            DisplayMessage(JsonConvert.SerializeObject(model));
            DisplayMessage(DateTime.Now.ToLongDateTimeString());
            RedisRowHelper_FuzzyQueryByMultiKeys(model);
            RedisMultiKeysInSetHelper_GetIntersectList(model);
            RedisTableHelper_GetIntersectList(model);

            model = new RPublish_Relation()
            {
                FixIID = 122,
                RelationType = "SUP"
            };

            DisplayMessage(JsonConvert.SerializeObject(model));
            DisplayMessage(DateTime.Now.ToLongDateTimeString());
            RedisRowHelper_FuzzyQueryByMultiKeys(model);
            RedisMultiKeysInSetHelper_GetIntersectList(model);
            RedisTableHelper_GetIntersectList(model);
        }

        #endregion

        #region RedisRowHelper

        private List<RPublish_Relation> RedisRowHelper_FuzzyQueryByMultiKeys(RPublish_Relation model)
        {
            DisplayMessage("RedisRowHelper_FuzzyQueryByMultiKeys:");
            var list = redisRowHelper.FuzzyQueryByMultiKeys(model);
            DisplayMessage(DateTime.Now.ToLongDateTimeString());
            return list;
        }

        #endregion

        #region RedisMultiKeysInSetHelper

        private List<RPublish_Relation> RedisMultiKeysInSetHelper_GetIntersectList(RPublish_Relation model)
        {
            DisplayMessage("RedisMultiKeysInSetHelper_GetIntersectList:");
            var list = redisMultiKeysInSetHelper.GetIntersectList(model);
            DisplayMessage(DateTime.Now.ToLongDateTimeString());
            return list;
        }

        #endregion

        #region RedisTableHelper

        private List<RPublish_Relation> RedisTableHelper_GetList()
        {
            DisplayMessage("RedisTableHelper_GetList:");
            var list = redisTableHelper.GetList();
            DisplayMessage(DateTime.Now.ToLongDateTimeString());
            return list;
        }

        private List<RPublish_Relation> RedisTableHelper_GetIntersectList(RPublish_Relation model)
        {
            DisplayMessage("RedisTableHelper_GetIntersectList:");
            var list = redisTableHelper.GetIntersectList(model);
            DisplayMessage(DateTime.Now.ToLongDateTimeString());
            return list;
        }

        #endregion
    }
}