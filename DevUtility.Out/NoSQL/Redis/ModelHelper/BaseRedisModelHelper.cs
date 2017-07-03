using DevUtility.Com.Application.ComAttributes;
using DevUtility.Com.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis.ModelHelper
{
    public class BaseRedisModelHelper<TModel>
        where TModel : class, new()
    {
        #region Variables

        protected string className = "";

        protected RedisConfig redisConfig = null;

        protected RedisHelper redisHelper = null;

        protected List<PropertyInfo> properties = new List<PropertyInfo>();

        protected List<PropertyInfo> primaryKeysProperties = new List<PropertyInfo>();

        protected List<PropertyInfo> redisIndexProperties = new List<PropertyInfo>();

        #endregion

        #region Constructor

        public BaseRedisModelHelper(RedisConfig redisConfig)
        {
            this.redisConfig = redisConfig;
            this.redisHelper = new RedisHelper(redisConfig);
            this.Init();
        }

        #endregion

        #region Init

        private void Init()
        {
            Type type = typeof(TModel);
            className = type.Name;
            properties = PropertyHelper.GetProperties<TModel>();
            primaryKeysProperties = PropertyHelper.FiltrateByAttribute<PrimaryKeyAttribute>(properties);

            if (primaryKeysProperties.Count > 1)
            {
                redisIndexProperties.AddRange(primaryKeysProperties);
            }

            redisIndexProperties.AddRange(PropertyHelper.FiltrateByAttribute<RedisIndexAttribute>(properties));
        }

        #endregion
    }
}