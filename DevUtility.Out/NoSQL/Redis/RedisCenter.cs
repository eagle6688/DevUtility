using DevUtility.Com.Base;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis
{
    public class RedisCenter : SingletonInstance<RedisCenter>
    {
        #region Variables

        volatile static object locker = new object();

        RedisClientManagerConfig redisClientManagerConfig = new RedisClientManagerConfig();

        List<RedisHostConfig> redisHostsConfigList = new List<RedisHostConfig>();

        #endregion

        #region Constructor

        public RedisCenter()
        {
            redisClientManagerConfig.MaxWritePoolSize = 10;
            redisClientManagerConfig.MaxReadPoolSize = 10;
            redisClientManagerConfig.AutoStart = true;
        }

        #endregion

        #region Get Redis Mangager

        public PooledRedisClientManager GetManager(RedisConfig redisConfig)
        {
            lock (locker)
            {
                if (redisHostsConfigList == null || redisHostsConfigList.Count == 0)
                {
                    return GetPooledRedisClientManager(redisConfig);
                }

                var redisManagerConfig = redisHostsConfigList.FirstOrDefault(q => q.Config.ConnectionString == redisConfig.ConnectionString && q.Config.Db == redisConfig.Db);

                if (redisManagerConfig != null && redisManagerConfig.RedisClientManager != null)
                {
                    return redisManagerConfig.RedisClientManager;
                }

                return GetPooledRedisClientManager(redisConfig);
            }
        }

        #endregion

        #region Get PooledRedisClientManager

        private PooledRedisClientManager GetPooledRedisClientManager(RedisConfig redisConfig)
        {
            redisClientManagerConfig.DefaultDb = redisConfig.Db;
            var hosts = new List<string>() { redisConfig.ConnectionString };
            var pooledRedisClientManager = new PooledRedisClientManager(hosts, hosts, redisClientManagerConfig);
            redisConfig.SetPooledRedisClientManager(ref pooledRedisClientManager);

            redisHostsConfigList.Add(new RedisHostConfig()
            {
                Config = redisConfig,
                RedisClientManager = pooledRedisClientManager
            });

            return pooledRedisClientManager;
        }

        #endregion
    }
}