using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis.ModelHelper
{
    /// <summary>
    /// One Table is a Hash.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class RedisTableHelper<TModel> : BaseRedisDataHelper<TModel>, IRedisModelHelper<TModel>
        where TModel : class, new()
    {
        /// <summary>
        /// 0: Table Name
        /// </summary>
        public const string KeyFormat = "$d_{0}";

        #region Constructor

        public RedisTableHelper(RedisConfig redisConfig) : base(redisConfig)
        {
        }

        #endregion

        #region Get Key

        public string GetKey()
        {
            return string.Concat(redisConfig.KeyNamePrefix, string.Format(KeyFormat, className));
        }

        public string GetField(TModel model)
        {
            return RedisCommon.GetPrimaryKeysValuesStr<TModel>(model, primaryKeysProperties);
        }

        public List<string> GetFields(List<TModel> list)
        {
            HashSet<string> fields = new HashSet<string>();

            foreach (var model in list)
            {
                string field = GetField(model);
                fields.Add(field);
            }

            return fields.ToList();
        }

        #endregion

        #region Get

        public TModel GetModel(string primaryKeyValue)
        {
            string value = redisHelper.HGet(GetKey(), primaryKeyValue);
            return JsonSerializer.DeserializeFromString<TModel>(value);
        }

        #endregion

        #region Get list

        public List<TModel> GetList()
        {
            var list = new List<TModel>();
            var values = redisHelper.HGetValues(GetKey());

            foreach (var value in values)
            {
                list.Add(JsonSerializer.DeserializeFromString<TModel>(value));
            }

            return list;
        }

        public List<TModel> GetList(List<string> keys)
        {
            var list = new List<TModel>();
            var values = redisHelper.HGetValues(keys);

            foreach (var value in values)
            {
                list.Add(JsonSerializer.DeserializeFromString<TModel>(value));
            }

            return list;
        }

        public List<TModel> GetListByFields(List<string> fields)
        {
            var list = new List<TModel>();
            var values = redisHelper.HGetValues(GetKey(), fields);

            foreach (var value in values)
            {
                list.Add(JsonSerializer.DeserializeFromString<TModel>(value));
            }

            return list;
        }

        #endregion

        #region Get List by Indexes

        public List<TModel> GetListByIndexes(List<string> indexes)
        {
            var list = new List<TModel>();
            var values = redisHelper.HGetValues(GetKey(), indexes);

            foreach (var value in values)
            {
                list.Add(JsonSerializer.DeserializeFromString<TModel>(value));
            }

            return list;
        }

        public List<TModel> GetIntersectList(TModel model)
        {
            var indexes = redisIndexHelper.GetIntersectIndexesByMultiKeys(model);
            return GetListByIndexes(indexes);
        }

        #endregion

        #region Save

        public void SaveData(List<TModel> list)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (var model in list)
            {
                string field = RedisCommon.GetPrimaryKeysValuesStr<TModel>(model, primaryKeysProperties);

                if (!string.IsNullOrEmpty(field))
                {
                    dictionary.Add(field, JsonSerializer.SerializeToString<TModel>(model));
                }
            }

            redisHelper.HSet(GetKey(), dictionary);
        }

        public void Save(List<TModel> list)
        {
            SaveData(list);
            redisIndexHelper.Save(list);
        }

        #endregion

        #region Delete

        public void Delete(List<TModel> list)
        {
            redisIndexHelper.Delete(list);
            DeleteData(list);
        }

        public bool DeleteData(List<TModel> list)
        {
            var keys = GetFields(list);
            return redisHelper.HRemove(GetKey(), keys);
        }

        public bool Delete(string primaryKeyValue)
        {
            TModel model = GetModel(primaryKeyValue);

            if (model == null)
            {
                return true;
            }

            redisIndexHelper.Delete(model);
            return redisHelper.HRemove(GetKey(), primaryKeyValue);
        }

        #endregion
    }
}