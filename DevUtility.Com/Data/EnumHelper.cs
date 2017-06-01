using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Data
{
    public class EnumHelper
    {
        #region Get Type

        public static T GetType<T>(string name)
        {
            string value = name.ToLower();

            foreach (string itemName in Enum.GetNames(typeof(T)))
            {
                if (value == itemName.ToLower())
                {
                    return (T)Enum.Parse(typeof(T), itemName);
                }
            }

            return default(T);
        }

        #endregion
    }
}