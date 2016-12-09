using DevUtility.Out.NoSQL.Redis;
using DevUtility.Test.Common.Winform;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis.HashHelper
{
    public class GetValueByKeyAndFieldService : BaseAppService
    {
        #region Variables

        string key = "";

        string field = "";

        RedisHelper redisHelper;

        #endregion

        #region Constructor

        public GetValueByKeyAndFieldService(string host, string password, string key, string field)
        {
            var config = RedisConfigHelper.DefaultRedisConfig;
            config.Host = host;
            config.Password = password;

            this.key = key;
            this.field = field;
            redisHelper = new RedisHelper(config);
        }

        #endregion

        #region Start

        public override void Start()
        {
            string value = redisHelper.HGet(key, field);
            DisplayMessage(value);
        }

        #endregion
    }
}