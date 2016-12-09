using DevUtility.Out.NoSQL.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Common.Winform
{
    public class RedisConfigHelper
    {
        public static RedisConfig DefaultRedisConfig
        {
            get
            {
                return new RedisConfig()
                {
                    Host = "10.100.97.64",
                    Port = 6379,
                    Db = 0,
                    Password = "111111"
                };
            }
        }

        public static RedisConfig DefaultIndexRedisConfig
        {
            get
            {
                var redisConfig = DefaultRedisConfig;
                redisConfig.Db = 1;
                return redisConfig;
            }
        }

        public static RedisConfig GetRedisConfig(int db)
        {
            var redisConfig = DefaultRedisConfig;
            redisConfig.Db = db;
            return redisConfig;
        }
    }
}