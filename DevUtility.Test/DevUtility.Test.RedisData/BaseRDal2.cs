using DevUtility.Out.NoSQL.Redis.ModelHelper;
using DevUtility.Test.Common.Winform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.RedisData
{
    public class BaseRDal2<TModel> where TModel : class, new()
    {
        #region Variables

        protected RedisTableHelper<TModel> redisTableHelper = new RedisTableHelper<TModel>(RedisConfigHelper.DefaultRedisConfig);

        #endregion

        public BaseRDal2(string host, string password)
        {
            var redisConfig = RedisConfigHelper.DefaultRedisConfig;
            redisConfig.Host = host;
            redisConfig.Password = password;
            redisTableHelper = new RedisTableHelper<TModel>(redisConfig);
        }

        #region Get List

        public List<TModel> GetList()
        {
            return redisTableHelper.GetList();
        }

        public List<TModel> GetIntersectList(TModel model)
        {
            return redisTableHelper.GetIntersectList(model);
        }

        #endregion
    }
}