using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Base
{
    public class AttributeHelper
    {
        #region Exists Attribute

        public static bool ExistsAttribute<TClass, TAttribute>() 
            where TClass : class 
            where TAttribute : Attribute
        {
            var attribute = Attribute.GetCustomAttribute(typeof(TClass), typeof(TAttribute));

            if (attribute != null)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}