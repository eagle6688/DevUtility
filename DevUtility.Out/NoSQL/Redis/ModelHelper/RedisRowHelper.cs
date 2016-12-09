using DevUtility.Com.Data;
using DevUtility.Com.Extension.SystemCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis.ModelHelper
{
    /// <summary>
    /// One row is a Hash.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class RedisRowHelper<TModel> : BaseRedisDataHelper<TModel>, IRedisModelHelper<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// 0: Model class name
        /// 1: Primary key and value string
        /// </summary>
        public const string KeyFormat = "$d_r_{0}@{1}";

        #region Constructor

        public RedisRowHelper(RedisConfig redisConfig) : base(redisConfig)
        {
        }

        #endregion

        #region Create Instance

        public static RedisRowHelper<TModel> CreateInstance(RedisConfig redisConfig)
        {
            return new RedisRowHelper<TModel>(redisConfig);
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

        public List<string> GetKeys(List<string> primaryKeysValues)
        {
            List<string> list = new List<string>();

            foreach (string primaryKeyValue in primaryKeysValues)
            {
                list.Add(GetKey(primaryKeyValue));
            }

            return list;
        }

        #endregion

        #region Get

        public TModel GetModel(string key)
        {
            Dictionary<string, string> dictionary = redisHelper.HGet(key);
            return dictionary.ToModel<TModel>(properties);
        }

        public TModel GetModelByPrimaryKeyValue(string value)
        {
            string key = GetKey(value);
            return GetModel(key);
        }

        public TModel GetModelByPrimaryKeys(TModel model)
        {
            string key = GetKey(model);
            return GetModel(key);
        }

        #endregion

        #region Get list

        public List<TModel> GetList()
        {
            string pattern = GetKey();
            var keys = redisHelper.SearchKeys(pattern);
            return GetList(keys);
        }

        public List<TModel> GetList(List<string> keys)
        {
            List<TModel> list = new List<TModel>();
            var dictionaries = redisHelper.HGetDictionaries(keys);

            if (dictionaries == null || dictionaries.Count == 0)
            {
                return list;
            }

            foreach (var dictionary in dictionaries)
            {
                var model = dictionary.ToModel<TModel>(properties);

                if (model != null)
                {
                    list.Add(model);
                }
            }

            return list;
        }

        public List<TModel> GetListByPrimaryKeys(List<string> primarykeys)
        {
            var keys = GetKeys(primarykeys);
            return GetList(keys);
        }

        #endregion

        #region Get List by Index

        private List<string> GetKeysByIndexes(List<string> indexes)
        {
            List<string> keys = new List<string>();

            foreach (string index in indexes)
            {
                keys.Add(GetKey(index));
            }

            return keys;
        }

        public List<TModel> GetListByIndex(string field, string value)
        {
            var indexes = redisIndexHelper.GetIndexes(field, value);
            return GetListByIndexes(indexes);
        }

        public List<TModel> GetListByIndexes(List<string> indexes)
        {
            var keys = GetKeysByIndexes(indexes);
            return GetList(keys);
        }

        public List<TModel> GetListByIntersectIndexes(TModel model)
        {
            var indexes = redisIndexHelper.GetIntersectIndexesByMultiKeys(model);
            return GetListByIndexes(indexes);
        }

        public List<TModel> GetListByIntersectIndexes(Dictionary<string, string> fieldsValuesDic)
        {
            var indexes = redisIndexHelper.GetIntersectIndexes(fieldsValuesDic);
            return GetListByIndexes(indexes);
        }

        public List<TModel> GetListByUnionIndexes(TModel model)
        {
            var indexes = redisIndexHelper.GetUnionIndexesByMultiKeys(model);
            return GetListByIndexes(indexes);
        }

        public List<TModel> GetListByUnionIndexes(Dictionary<string, string> fieldsValuesDic)
        {
            var indexes = redisIndexHelper.GetUnionIndexes(fieldsValuesDic);
            return GetListByIndexes(indexes);
        }

        #endregion

        #region Fuzzy query

        /// <summary>
        /// Fuzzy query by multi keys. 
        /// If model within all of keys, results are same as GetList.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<TModel> FuzzyQueryByMultiKeys(TModel model)
        {
            string keyPattern = GetKey(model);
            var keys = redisHelper.SearchKeys(keyPattern);
            return GetList(keys);
        }

        #endregion

        #region Save

        public void Save(List<TModel> list)
        {
            if (list == null || list.Count == 0)
            {
                return;
            }

            var hashDictionary = new Dictionary<string, IEnumerable<KeyValuePair<string, string>>>();

            foreach (var model in list)
            {
                string key = GetKey(model);
                hashDictionary.Add(key, EntityHelper.ToKeyValuePairs<TModel>(model, properties));
            }

            redisHelper.HSet(hashDictionary);
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