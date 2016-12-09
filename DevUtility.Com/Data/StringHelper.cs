using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DevUtility.Com.Data
{
    public class StringHelper
    {
        #region Is Numeric

        public static bool IsNumeric(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            return Regex.IsMatch(value, @"^[a-zA-Z0-9]*$");
        }

        #endregion
    }
}