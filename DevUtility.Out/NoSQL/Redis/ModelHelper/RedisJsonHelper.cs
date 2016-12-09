using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis.ModelHelper
{
    /// <summary>
    /// One model is a Json string.
    /// </summary>
    public class RedisJsonHelper<TModel> : BaseRedisDataHelper<TModel>, IRedisModelHelper<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// 0: Model class name
        /// 1: Primary key and value string
        /// </summary>
        public const string KeyFormat = "$d_j_{0}@{1}";

        #region Constructor

        public RedisJsonHelper(RedisConfig redisConfig) : base(redisConfig)
        {
        }

        #endregion

        #region Get Key

        public string GetKey()
        {
            return GetKey(RedisCommon.WildCard);
        }

        public string GetKey(string value)
        {
            return string.Concat(redisConfig.KeyNamePrefix, string.Format(KeyFormat, className, value));
        }

        public string GetKey(TModel model)
        {
            string value = "";

            if (primaryKeysProperties.Count == 0)
            {
                value = RedisCommon.WildCard;
            }
            else if (primaryKeysProperties.Count == 1)
            {
                value = RedisCommon.GetPropertyValueStr<TModel>(model, primaryKeysProperties[0], RedisCommon.WildCard);
            }
            else
            {
                value = RedisCommon.GetPropertiesKeysValuesStr<TModel>(model, primaryKeysProperties, RedisCommon.WildCard);
            }

            return GetKey(value);
        }

        #endregion

        #region Get List

        public List<TModel> GetList()
        {
            throw new NotImplementedException();
        }

        public List<TModel> GetList(List<string> keys)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Get List by Indexes

        public List<TModel> GetListByIndexes(List<string> indexes)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Save

        public void Save(List<TModel> list)
        {
            if (list == null || list.Count == 0)
            {
                return;
            }

            Dictionary<string, TModel> dictionary = new Dictionary<string, TModel>();

            foreach (var model in list)
            {
                string key = GetKey(model);
                dictionary.Add(key, model);
            }

            redisHelper.SetAll<TModel>(dictionary);
        }

        #endregion

        #region Delete

        public void Delete(List<TModel> list)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}