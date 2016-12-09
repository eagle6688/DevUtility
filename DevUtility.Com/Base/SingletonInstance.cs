using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Base
{
    public class SingletonInstance<T> where T : class, new()
    {
        #region Variable

        volatile static object locker = new object();

        static T instance;

        #endregion

        #region Property

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion
    }
}