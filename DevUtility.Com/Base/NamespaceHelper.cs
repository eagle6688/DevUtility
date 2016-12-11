using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Base
{
    public class NamespaceHelper
    {
        #region Get Namespace

        public static string GetNamespace(string className)
        {
            var array = className.Split('.');
            return string.Join(".", array.Take(array.Length - 1));
        }

        #endregion
    }
}