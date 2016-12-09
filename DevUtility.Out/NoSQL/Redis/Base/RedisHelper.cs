using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis
{
    public partial class RedisHelper : BaseRedisHelper<RedisHelper>
    {
        #region Constructor

        public RedisHelper() { }

        public RedisHelper(RedisConfig redisConfig)
        {
            this.Config = redisConfig;
        }

        public RedisHelper(string host, int port, string password)
        {
            Config = new RedisConfig
            {
                Host = host,
                Port = port,
                Password = password
            };
        }

        public RedisHelper(string host, int port, string password, int db)
        {
            Config = new RedisConfig
            {
                Host = host,
                Port = port,
                Password = password,
                Db = db
            };
        }

        #endregion

        #region Is Connected

        public bool IsConnected()
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (RedisClient redisClient = (RedisClient)pooledRedisClientManager.GetClient())
            {
                return redisClient.Ping();
            }
        }

        #endregion

        #region Get

        public string GetValue(string key)
        {
            return GetValue<string>(key);
        }

        public T GetValue<T>(string key)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                return redisClient.Get<T>(key);
            }
        }

        #endregion

        #region Set

        public bool Set(string key, string value)
        {
            return Set<string>(key, value);
        }

        public bool Set<T>(string key, T value)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetClient())
            {
                return redisClient.Set<T>(key, value);
            }
        }

        #endregion

        #region Set List

        /// <summary>
        /// If T is a Model type, redis will store it's json string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public void SetAll<T>(Dictionary<string, T> dictionary)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (IRedisClient redisClient = pooledRedisClientManager.GetClient())
            {
                redisClient.SetAll<T>(dictionary);
            }
        }

        #endregion

        #region Remove

        public bool Remove(string key)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetClient())
            {
                return redisClient.Remove(key);
            }
        }

        public void RemoveAll(IEnumerable<string> keys)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetClient())
            {
                redisClient.RemoveAll(keys);
            }
        }

        #endregion

        #region Clear

        public void Clear()
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetClient())
            {
                redisClient.FlushAll();
            }
        }

        public void ClearDB()
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetClient())
            {
                redisClient.FlushDb();
            }
        }

        #endregion

        #region Search

        /// <summary>
        /// Search keys by 'pattern'
        /// </summary>
        /// <param name="pattern">* matches any length and any char; ? matches one char; [c1c2], chars in [], for instance c1 and c2 will be matched. </param>
        /// <returns></returns>
        public List<string> SearchKeys(string pattern = "*")
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                return redisClient.SearchKeys(pattern);
            }
        }

        #endregion
    }
}