using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Base.Reflection
{
    public class TypeHelper
    {
        #region Is type

        public static bool IsType(Type type, string name)
        {
            if (type.Name.Equals(name))
            {
                return true;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var array = type.GetGenericArguments();

                if (array == null || array.Length == 0)
                {
                    return false;
                }

                if (array[0].Name.Equals(name))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}