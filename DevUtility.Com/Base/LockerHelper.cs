using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Base
{
    public class LockerHelper : SingletonInstance<LockerHelper>
    {
        #region Variables

        public const string LockerFormat = "{0}-{1}";

        List<string> lockers = new List<string>();

        #endregion

        #region Get Locker

        public string GetLocker(string name)
        {
            lock (this)
            {
                foreach (string locker in lockers)
                {
                    if (locker.Equals(name))
                    {
                        return locker;
                    }
                }

                lockers.Add(name);
                return name;
            }
        }

        public string GetLocker<T>(string value) where T : class, new()
        {
            string name = string.Format(LockerFormat, value, typeof(T).FullName);
            return GetLocker(name);
        }

        #endregion
    }
}