using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis
{
    public abstract class BaseRedisHelper<TClass> where TClass : BaseRedisHelper<TClass>, new()
    {
        #region Properties

        public RedisConfig Config { set; get; }

        #endregion

        #region Create instance

        public static TClass CreateInstance(RedisConfig redisConfig)
        {
            TClass instance = new TClass();
            instance.Config = redisConfig;
            return instance;
        }

        #endregion
    }
}