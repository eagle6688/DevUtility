using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis.ModelHelper
{
    /// <summary>
    /// Multi keys table is stored in a HashSet
    /// </summary>
    public class RedisMultiKeysInSetHelper<TModel> : BaseRedisModelHelper<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// 0: Model class name
        /// 1: field name and value string
        /// </summary>
        public const string KeyFormat = "$d_mk_{0}@{1}";

        #region Constructor

        public RedisMultiKeysInSetHelper(RedisConfig redisConfig) : base(redisConfig)
        {
        }

        #endregion

        #region Get Key

        public string GetKey(string keyValueStr)
        {
            return string.Concat(redisConfig.KeyNamePrefix, string.Format(KeyFormat, className, keyValueStr));
        }

        public string GetKey(string field, string value)
        {
            string keyValueStr = RedisCommon.GetKeyValueStr(field, value);
            return GetKey(keyValueStr);
        }

        public List<string> GetKeys(TModel model)
        {
            List<string> keys = new List<string>();

            foreach (var indexProperty in redisIndexProperties)
            {
                string value = RedisCommon.GetPropertyValueStr<TModel>(model, indexProperty);

                if (!string.IsNullOrEmpty(value))
                {
                    keys.Add(GetKey(indexProperty.Name, value));
                }
            }

            return keys;
        }

        #endregion

        #region Get List

        public List<TModel> GetIntersectList(List<string> keys)
        {
            var list = new List<TModel>();
            var values = redisHelper.SGetIntersect(keys);

            foreach (var item in values)
            {
                list.Add(JsonSerializer.DeserializeFromString<TModel>(item));
            }

            return list;
        }

        public List<TModel> GetIntersectList(TModel model)
        {
            var keys = GetKeys(model);
            return GetIntersectList(keys);
        }

        #endregion

        #region Convert To Dictionary

        public Dictionary<string, HashSet<string>> ConvertToDictionary(List<TModel> list)
        {
            Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
            object propertyValue = null;
            string propertyValueStr = "";

            foreach (var property in redisIndexProperties)
            {
                foreach (var model in list)
                {
                    propertyValue = property.GetValue(model, null);

                    if (propertyValue == null)
                    {
                        continue;
                    }

                    propertyValueStr = propertyValue.ToString();

                    if (string.IsNullOrWhiteSpace(propertyValueStr))
                    {
                        continue;
                    }

                    bool isExisted = false;
                    string key = GetKey(property.Name, propertyValueStr);
                    string value = JsonSerializer.SerializeToString<TModel>(model);

                    foreach (var item in dictionary)
                    {
                        if (item.Key == key)
                        {
                            item.Value.Add(value);
                            isExisted = true;
                            break;
                        }
                    }

                    if (!isExisted)
                    {
                        dictionary.Add(key, new HashSet<string>(new List<string>() { value }));
                    }

                    propertyValue = null;
                    propertyValueStr = null;
                }
            }

            return dictionary;
        }

        #endregion

        #region Save

        public void Save(List<TModel> list)
        {
            var dictionary = ConvertToDictionary(list);
            redisHelper.SAdd(dictionary);
        }

        #endregion
    }
}