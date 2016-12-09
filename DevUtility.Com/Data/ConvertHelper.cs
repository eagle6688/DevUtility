using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Data
{
    public class ConvertHelper
    {
        #region Bytes to Hex String

        public static string BytesToHexString(byte[] bytes)
        {
            StringBuilder result = new StringBuilder();

            foreach (byte b in bytes)
            {
                result.AppendFormat("{0:X2}", b);
            }

            return result.ToString();
        }

        #endregion

        #region Hex String to Bytes

        public static byte[] HexStringToBytes(string hexString)
        {
            byte[] data = new byte[hexString.Length / 2];

            for (int i = 0; i < hexString.Length / 2; i++)
            {
                int value = Convert.ToInt32(hexString.Substring(i * 2, 2), 16);
                data[i] = (byte)value;
            }

            return data;
        }

        #endregion

        #region To int list

        public static List<int> ToIntList(List<string> strList)
        {
            int value = 0;
            List<int> list = new List<int>();

            foreach (var str in strList)
            {
                if (int.TryParse(str, out value))
                {
                    list.Add(value);
                }
            }

            return list;
        }

        #endregion

        #region To long list

        public static List<long> ToLongList(List<string> strList)
        {
            long value = 0;
            List<long> list = new List<long>();

            foreach (var str in strList)
            {
                if (long.TryParse(str, out value))
                {
                    list.Add(value);
                }
            }

            return list;
        }

        #endregion

        #region To guid list

        public static List<Guid> ToGuidList(List<string> strList)
        {
            Guid value = Guid.Empty;
            List<Guid> list = new List<Guid>();

            foreach (var str in strList)
            {
                if (Guid.TryParse(str, out value))
                {
                    list.Add(value);
                }
            }

            return list;
        }

        #endregion
    }
}