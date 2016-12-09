using DevUtility.Com.Application.Log;
using DevUtility.Com.Base;
using DevUtility.Out.NoSQL.Redis.ModelHelper;
using DevUtility.Test.Common.Winform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUtility.Test.RedisData
{
    public class BaseRDal<TClass, TModel> : SingletonInstance<TClass>
        where TClass : class, new()
        where TModel : class, new()
    {
        #region Variables

        protected RedisTableHelper<TModel> redisTableHelper = new RedisTableHelper<TModel>(RedisConfigHelper.DefaultRedisConfig);

        #endregion

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

        #region Save models

        public bool Save(TModel model)
        {
            return SaveList(new List<TModel>() { model });
        }

        public bool SaveList(List<TModel> list)
        {
            try
            {
                redisTableHelper.Save(list);
                return true;
            }
            catch (Exception exception)
            {
                LogHelper.Error(exception);
                return false;
            }
        }

        #endregion

        #region Delete

        public bool Delete(string primaryKeyValue)
        {
            try
            {
                return redisTableHelper.Delete(primaryKeyValue);
            }
            catch (Exception exception)
            {
                LogHelper.Error(exception);
                return false;
            }
        }

        public bool Delete(List<TModel> list)
        {
            try
            {
                redisTableHelper.Delete(list);
                return true;
            }
            catch (Exception exception)
            {
                LogHelper.Error(exception);
                return false;
            }
        }

        #endregion
    }
}