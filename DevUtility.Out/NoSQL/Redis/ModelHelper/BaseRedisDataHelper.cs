using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis.ModelHelper
{
    public class BaseRedisDataHelper<TModel> : BaseRedisModelHelper<TModel>
        where TModel : class, new()
    {
        #region Variables

        protected RedisIndexHelper<TModel> redisIndexHelper;

        #endregion

        #region Constructor

        public BaseRedisDataHelper(RedisConfig redisConfig) : base(redisConfig)
        {
            redisIndexHelper = new RedisIndexHelper<TModel>(redisConfig);
        }

        #endregion
    }
}