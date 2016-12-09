using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Test.Service.MVC.Basic
{
    public class RecursiveService
    {
        #region TestStackOverflow

        public static void TestStackOverflow(int number)
        {
            if (number > 30000)
            {
                return;
            }

            TestStackOverflow(number + 1);
        }

        #endregion
    }
}