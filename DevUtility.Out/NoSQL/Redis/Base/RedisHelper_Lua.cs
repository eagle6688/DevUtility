using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis
{
    public partial class RedisHelper
    {
        #region Execute Lua

        public string ExecuteLua(string luaScripts, List<string> keys, List<string> args)
        {
            using (var pooledRedisClientManager = RedisCenter.Instance.GetManager(Config))
            using (var redisClient = (RedisClient)pooledRedisClientManager.GetClient())
            {
                return redisClient.ExecLuaAsString(luaScripts, keys.ToArray(), args.ToArray());
            }
        }

        #endregion
    }
}