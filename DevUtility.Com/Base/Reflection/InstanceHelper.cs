using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Com.Base.Reflection
{
    public class InstanceHelper
    {
        public static object ExecuteMethod<T>(T instance, string method, params object[] parameters)
        {
            Type type = typeof(T);
            MethodInfo methodInfo = type.GetMethod(method);

            if (methodInfo == null)
            {
                throw new Exception("Method not found!");
            }

            return methodInfo.Invoke(instance, parameters);
        }
    }
}