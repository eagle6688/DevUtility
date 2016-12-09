using DevUtility.Out.NoSQL.Redis;
using DevUtility.Test.Common.Winform;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis.SetHelper
{
    public class GetValuesService : BaseAppService
    {
        #region Variables

        string key = "";

        string value = "";

        RedisHelper redisHelper;

        #endregion

        #region Constructor

        public GetValuesService(string host, string password, string key, string value)
        {
            var config = RedisConfigHelper.DefaultRedisConfig;
            config.Host = host;
            config.Password = password;

            this.key = key;
            this.value = value;
            redisHelper = new RedisHelper(config);
        }

        #endregion

        #region Start

        public override void Start()
        {
            var list = redisHelper.SGet(key);

            foreach (var item in list)
            {
                DisplayMessage(item);
            }
        }

        #endregion
    }
}