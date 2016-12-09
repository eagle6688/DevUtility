using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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

        #region ThousandsPlace

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
    }
}