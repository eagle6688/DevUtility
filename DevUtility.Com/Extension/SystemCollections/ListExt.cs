using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Extension.SystemCollections
{
    public static class ListExt
    {
        #region Is existed

        public static bool IsExisted<T>(this List<T> list, T value)
        {
            bool repeated = false;

            foreach (T item in list)
            {
                if (value.Equals(item))
                {
                    repeated = true;
                    break;
                }
            }

            return repeated;
        }

        #endregion

        #region Insert into list

        public static List<T> AddUnique<T>(this List<T> list, T value)
        {
            if (!list.IsExisted<T>(value))
            {
                list.Add(value);
            }

            return list;
        }

        #endregion
    }
}