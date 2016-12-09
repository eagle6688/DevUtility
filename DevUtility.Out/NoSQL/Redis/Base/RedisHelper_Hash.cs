using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis
{
    public partial class RedisHelper
    {
        #region Set

        public void HSet(string key, IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetClient())
            {
                redisClient.SetRangeInHash(key, keyValuePairs);
            }
        }

        public void HSet(Dictionary<string, IEnumerable<KeyValuePair<string, string>>> hashDictionary)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (IRedisClient redisClient = pooledRedisClientManager.GetClient())
            {
                foreach (var hash in hashDictionary)
                {
                    redisClient.SetRangeInHash(hash.Key, hash.Value);
                }
            }
        }

        #endregion

        #region Get

        public Dictionary<string, string> HGet(string key)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                return redisClient.GetAllEntriesFromHash(key);
            }
        }

        public string HGet(string key, string field)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                return redisClient.GetValueFromHash(key, field);
            }
        }

        #endregion

        #region Get values

        public List<string> HGetValues(string key)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                return redisClient.GetHashValues(key);
            }
        }

        public List<string> HGetValues(List<string> keys)
        {
            List<string> list = new List<string>();

            if (keys == null || keys.Count == 0)
            {
                return list;
            }

            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                foreach (string key in keys)
                {
                    list.AddRange(redisClient.GetHashValues(key));
                }
            }

            return list;
        }

        public List<string> HGetValues(string key, List<string> fields)
        {
            if (string.IsNullOrEmpty(key) || fields.Count() == 0)
            {
                return new List<string>();
            }

            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                return redisClient.GetValuesFromHash(key, fields.ToArray());
            }
        }

        public List<Dictionary<string, string>> HGetDictionaries(List<string> keys)
        {
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            if (keys == null || keys.Count == 0)
            {
                return list;
            }

            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                foreach (string key in keys)
                {
                    list.Add(redisClient.GetAllEntriesFromHash(key));
                }
            }

            return list;
        }

        #endregion

        #region Remove

        public bool HRemove(string key, string field)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetClient())
            {
                return redisClient.RemoveEntryFromHash(key, field);
            }
        }

        public bool HRemove(string key, List<string> fields)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetClient())
            {
                foreach (string field in fields)
                {
                    if (!redisClient.RemoveEntryFromHash(key, field))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion
    }
}