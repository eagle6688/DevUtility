using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}