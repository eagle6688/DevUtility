using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.NoSQL.Redis.ModelHelper
{
    public interface IRedisModelHelper<TModel> where TModel : class, new()
    {
        string GetKey();

        void Save(List<TModel> list);

        void Delete(List<TModel> list);

        List<TModel> GetList();

        List<TModel> GetList(List<string> keys);

        List<TModel> GetListByIndexes(List<string> indexes);
    }
}