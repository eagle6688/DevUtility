using DevUtility.Com.Base;
using DevUtility.Com.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Com.Extension.SystemCollections
{
    public static class KeyValuePairExt
    {
        #region SetModel

        public static void SetModel<TModel>(this KeyValuePair<string, string> keyValuePair, ref TModel model) where TModel : class, new()
        {
            if (model == null)
            {
                return;
            }

            PropertyInfo propertyInfo = PropertyHelper.GetProperty<TModel>(model, keyValuePair.Key);

            if (propertyInfo != null)
            {
                EntityHelper.SetModel<TModel>(ref model, propertyInfo, keyValuePair.Value);
            }
        }

        #endregion
    }
}