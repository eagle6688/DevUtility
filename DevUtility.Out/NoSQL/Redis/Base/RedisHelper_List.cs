using DevUtility.Com.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis
{
    public partial class RedisHelper
    {
        #region Get

        public List<string> LGet(string key)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = pooledRedisClientManager.GetReadOnlyClient())
            {
                return redisClient.GetAllItemsFromList(key);
            }
        }

        public List<int> LGetInt(string key)
        {
            var list = LGet(key);
            return ConvertHelper.ToIntList(list);
        }

        public List<long> LGetLong(string key)
        {
            var list = LGet(key);
            return ConvertHelper.ToLongList(list);
        }

        public List<Guid> LGetGuid(string key)
        {
            var list = LGet(key);
            return ConvertHelper.ToGuidList(list);
        }

        #endregion
    }
}