using DevUtility.Com.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Data
{
    public class RandomHelper
    {
        #region Variable

        static Random random = new Random();

        #endregion

        #region Get verify code

        public static string GetVerifyCode(int length = 4)
        {
            StringBuilder result = new StringBuilder("");
            char code;
            int number;

            for (int i = 1; i <= length; i++)
            {
                number = random.Next(26 * i);
                code = (char)('0' + number % 10);
                result.Append(code);
            }

            return result.ToString();
        }

        #endregion

        #region Get random number

        public static int GetRandomNumber(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        public static string GetRandomNumber(int length)
        {
            Random random = new Random();
            StringBuilder result = new StringBuilder("");

            for (int i = 0; i < length; i++)
            {
                result.Append(random.Next(0, 10));
            }

            return result.ToString();
        }

        #endregion

        #region Get random string

        public static string GetRandomString(int length)
        {
            List<string> list = new List<string>();

            for (var i = 0; i < length; i++)
            {
                int[] array = new int[3];
                array[0] = random.Next(1, 10);
                array[1] = random.Next(65, 91);
                array[2] = random.Next(97, 123);
                int num = array[random.Next(0, 3)];
                list.Add(ASCIIHelper.GetASCIIChar(num));
            }

            return string.Join("", list);
        }

        #endregion
    }
}