using DevUtility.Out.NoSQL.Redis;
using DevUtility.Test.Common.Winform;
using DevUtility.Win.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.Winform.NoSQL.Redis.HashHelper
{
    public class GetAllByKeyService : BaseAppService
    {
        #region Variables

        string key = "";

        RedisHelper redisHelper;

        #endregion

        #region Constructor

        public GetAllByKeyService(string host, string password, string key)
        {
            var config = RedisConfigHelper.DefaultRedisConfig;
            config.Host = host;
            config.Password = password;

            this.key = key;
            redisHelper = new RedisHelper(config);
        }

        #endregion

        #region Start

        public override void Start()
        {
            var list = redisHelper.HGetValues(key);

            foreach (var item in list)
            {
                DisplayMessage(item);
            }
        }

        #endregion
    }
}