using DevUtility.Com.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis
{
    public partial class RedisHelper
    {
        #region Set

        public void SAdd(string key, string item)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetClient())
            {
                redisClient.AddItemToSet(key, item);
            }
        }

        public void SAdd(string key, List<string> items)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetClient())
            {
                redisClient.AddRangeToSet(key, items);
            }
        }

        public void SAdd(Dictionary<string, HashSet<string>> dictionary)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetClient())
            {
                foreach (var redisSet in dictionary)
                {
                    redisClient.AddRangeToSet(redisSet.Key, redisSet.Value.ToList());
                }
            }
        }

        #endregion

        #region Get

        public HashSet<string> SGet(string key)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                return redisClient.GetAllItemsFromSet(key);
            }
        }

        public List<long> SGetLongList(string key)
        {
            var hashSet = SGet(key);
            return ConvertHelper.ToLongList(hashSet.ToList());
        }

        public List<int> SGetIntList(string key)
        {
            var hashSet = SGet(key);
            return ConvertHelper.ToIntList(hashSet.ToList());
        }

        public List<Guid> SGetGuidList(string key)
        {
            var hashSet = SGet(key);
            return ConvertHelper.ToGuidList(hashSet.ToList());
        }

        #endregion

        #region Get from keys

        public HashSet<string> SGetIntersect(List<string> keys)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                return redisClient.GetIntersectFromSets(keys.ToArray());
            }
        }

        public HashSet<string> SGetUnion(List<string> keys)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                return redisClient.GetUnionFromSets(keys.ToArray());
            }
        }

        #endregion

        #region Del

        public void SDel(string key, string item)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                redisClient.RemoveItemFromSet(key, item);
            }
        }

        #endregion

        #region Exists

        public bool Exists(string key, string item)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                return redisClient.SetContainsItem(key, item);
            }
        }

        #endregion
    }
}