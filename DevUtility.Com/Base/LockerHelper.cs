using DevUtility.Com.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Com.Base
{
    public class LockerHelper : SingletonInstance<LockerHelper>
    {
        #region Variables

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

        #endregion
    }
}