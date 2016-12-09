using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis.ModelHelper
{
    public class RedisIndexHelper<TModel> : BaseRedisModelHelper<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// 0: Model class name
        /// 1: Field name and value string
        /// </summary>
        public const string KeyFormat = "$d_i_{0}@{1}";

        #region Constructor

        public RedisIndexHelper(RedisConfig redisConfig) : base(redisConfig)
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

        public List<string> GetKeys(Dictionary<string, string> dictionary)
        {
            List<string> list = new List<string>();

            foreach (var keyValuePair in dictionary)
            {
                list.Add(GetKey(keyValuePair.Key, keyValuePair.Value));
            }

            return list;
        }

        #endregion

        #region Get Index

        public List<string> GetIndexes(string field, string value)
        {
            string key = GetKey(field, value);
            return redisHelper.SGet(key).ToList();
        }

        public List<long> GetIndexesLong(string field, string value)
        {
            string key = GetKey(field, value);
            return redisHelper.SGetLongList(key);
        }

        public List<int> GetIndexesInt(string field, string value)
        {
            string key = GetKey(field, value);
            return redisHelper.SGetIntList(key);
        }

        public List<Guid> GetIndexesGuid(string field, string value)
        {
            string key = GetKey(field, value);
            return redisHelper.SGetGuidList(key);
        }

        public List<string> GetIntersectIndexes(Dictionary<string, string> fieldsValuesDic)
        {
            var keys = GetKeys(fieldsValuesDic);
            return redisHelper.SGetIntersect(keys).ToList();
        }

        public List<string> GetUnionIndexes(Dictionary<string, string> fieldsValuesDic)
        {
            var keys = GetKeys(fieldsValuesDic);
            return redisHelper.SGetUnion(keys).ToList();
        }

        public List<string> GetIntersectIndexesByMultiKeys(TModel model)
        {
            var indexesKeys = GetKeys(model);
            return redisHelper.SGetIntersect(indexesKeys).ToList();
        }

        public List<string> GetUnionIndexesByMultiKeys(TModel model)
        {
            var indexesKeys = GetKeys(model);
            return redisHelper.SGetUnion(indexesKeys).ToList();
        }

        #endregion

        #region Convert to indexes

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
                    string value = RedisCommon.GetPrimaryKeysValuesStr<TModel>(model, primaryKeysProperties);

                    if (string.IsNullOrEmpty(value))
                    {
                        continue;
                    }

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

        #region Delete

        public void Delete(TModel model)
        {
            var keys = GetKeys(model);
            string value = JsonSerializer.SerializeToString<TModel>(model);

            GetKeys(model).ForEach((key) =>
            {
                redisHelper.SDel(key, value);
            });
        }

        public void Delete(List<TModel> list)
        {
            foreach (var model in list)
            {
                Delete(model);
            }
        }

        #endregion
    }
}