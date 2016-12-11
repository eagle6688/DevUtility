using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevUtility.Com.Base.Reflection
{
    public class AssemblyHelper
    {
        #region Get Assembly Name

        public static string GetAssemblyName(string name, string version = "1.0.0.0", string culture = "neutral", string publicKey_token = "null")
        {
            return string.Format("{0}, Version={1}, Culture={2}, PublicKeyToken={3}", name, version, culture, publicKey_token);
        }

        #endregion

        #region Get Assembly

        public static Assembly GetAssemblyByReference(string referenceName, string version = "1.0.0.0", string culture = "neutral", string publicKey_token = "null")
        {
            string assemblyName = GetAssemblyName(referenceName);
            return Assembly.Load(assemblyName);
        }

        public static Assembly GetAssembly(string nameSpace)
        {
            return Assembly.Load(nameSpace);
        }

        #endregion

        #region Get Type

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className">Class name with namespace</param>
        /// <returns></returns>
        public static Type GetType(string className)
        {
            string nameSpace = NamespaceHelper.GetNamespace(className);
            Assembly assembly = GetAssembly(nameSpace);
            return assembly.GetType(className);
        }

        public static Type GetType(string referenceName, string className)
        {
            Assembly assembly = GetAssemblyByReference(referenceName);
            return assembly.GetType(className);
        }

        #endregion
    }
}