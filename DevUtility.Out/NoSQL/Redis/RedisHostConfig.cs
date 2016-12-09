using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis
{
    public class RedisHostConfig
    {
        #region Properties

        public RedisConfig Config { set; get; }

        public PooledRedisClientManager RedisClientManager { set; get; }

        #endregion

        #region Constructor

        public RedisHostConfig()
        {
            Config = new RedisConfig();
        }

        #endregion
    }
}