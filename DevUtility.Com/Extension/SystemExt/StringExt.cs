using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace DevUtility.Com.Extension.SystemExt
{
    public static class StringExt
    {
        #region Shield

        public static string Shield(this string value, int startIndex, int length = 0)
        {
            StringBuilder result = new StringBuilder("");

            string header = "";
            string tail = "";
            int endIndex = 0;

            if (startIndex > 0)
            {
                header = value.Substring(0, startIndex);
                result.Append(header);
            }

            if (length > 0)
            {
                endIndex = startIndex + length;
            }
            else
            {
                endIndex = value.Length;
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                result.Append("*");
            }

            if (endIndex < value.Length)
            {
                tail = value.Substring(endIndex);
                result.Append(tail);
            }

            return result.ToString();
        }

        #endregion

        #region Split To List

        public static List<string> SplitToList(this string value, string separator)
        {
            return value.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static List<string> SplitStringWithMultiSameChar(this string value, char separator)
        {
            List<string> list = new List<string>();

            if (string.IsNullOrEmpty(value))
            {
                return list;
            }

            int start = 0, index = 0;
            string str = value.Trim();
            char[] chars = str.ToCharArray();

            while ((index = str.IndexOf(separator, start)) != -1)
            {
                list.Add(str.Substring(start, index - start));
                start = index + 1;

                while (start < chars.Length && chars[start] == separator)
                {
                    start++;
                }
            }

            if (start < str.Length)
            {
                list.Add(str.Substring(start));
            }

            return list;
        }

        #endregion

        #region To TitleCase

        public static string ToTitleCase(this string value)
        {
            //Get the culture property of the thread.
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

            //Create TextInfo object.
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(value);
        }

        #endregion

        #region Thousands Place

        public static string ThousandsPlace(int number)
        {
            int index = 0;
            StringBuilder result = new StringBuilder("");
            char[] numberArray = number.ToString().ToCharArray();

            for (int i = numberArray.Length - 1; i > -1; i--)
            {
                index++;
                result.Insert(0, numberArray[i]);

                if (index % 3 == 0 && index < numberArray.Length)
                {
                    result.Insert(0, ",");
                }
            }

            return result.ToString();
        }

        #endregion

        #region Add time header

        public static string AddTimeHeader(this string str, string separator = "")
        {
            StringBuilder result = new StringBuilder(str);
            result.Insert(0, separator);
            result.Insert(0, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            return result.ToString();
        }

        #endregion

        #region Filter SQL

        public static string FilterSQL(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            List<string> list = new List<string>();
            list.Add(Regex.Replace(str, "select ", "", RegexOptions.IgnoreCase));
            list.Add(Regex.Replace(list.Last(), "insert ", "", RegexOptions.IgnoreCase));
            list.Add(Regex.Replace(list.Last(), "update ", "", RegexOptions.IgnoreCase));
            list.Add(Regex.Replace(list.Last(), "delete ", "", RegexOptions.IgnoreCase));
            list.Add(Regex.Replace(list.Last(), "drop  ", "", RegexOptions.IgnoreCase));
            list.Add(Regex.Replace(list.Last(), "truncate  ", "", RegexOptions.IgnoreCase));
            list.Add(Regex.Replace(list.Last(), "xp_cmdshell  ", "", RegexOptions.IgnoreCase));
            list.Add(Regex.Replace(list.Last(), "exec master", "", RegexOptions.IgnoreCase));
            list.Add(Regex.Replace(list.Last(), "net localgroup administrators", "", RegexOptions.IgnoreCase));
            list.Add(Regex.Replace(list.Last(), "net user", "", RegexOptions.IgnoreCase));

            return list.Last();
        }

        #endregion
    }
}