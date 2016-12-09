using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Base
{
    public class ASCIIHelper
    {
        #region Get ASCII char

        public static string GetASCIIChar(int asciiNum)
        {
            if (asciiNum < 10 && asciiNum > 0)
            {
                return asciiNum.ToString();
            }

            //A-Z, ASCII 65-90
            if (asciiNum > 64 && asciiNum < 91)
            {
                return ((char)asciiNum).ToString();
            }

            //a-z, ASCII 97-122
            if (asciiNum > 96 && asciiNum < 123)
            {
                return ((char)asciiNum).ToString();
            }

            return "";
        }

        #endregion
    }
}