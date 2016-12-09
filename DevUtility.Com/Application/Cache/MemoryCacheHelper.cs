using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace DevUtility.Com.Application.Cache
{
    public class MemoryCacheHelper
    {
        #region Variables

        private static readonly object locker = new object();

        #endregion

        #region Set

        public static void Set(string key, object value, int minutes)
        {
            TimeSpan timeSpan = new TimeSpan(0, minutes, 0);
            Set(key, value, timeSpan);
        }

        public static void Set(string key, object value, int minutes, CacheEntryUpdateCallback cacheEntryUpdateCallback)
        {
            TimeSpan timeSpan = new TimeSpan(0, minutes, 0);
            Set(key, value, timeSpan, null, cacheEntryUpdateCallback);
        }

        public static void Set(string key, object value, int hours, int minutes, int seconds)
        {
            TimeSpan timeSpan = new TimeSpan(hours, minutes, seconds);
            Set(key, value, timeSpan);
        }

        public static void Set(string key, object value, TimeSpan? slidingExpiration = null, DateTimeOffset? absoluteExpiration = null, CacheEntryUpdateCallback cacheEntryUpdateCallback = null)
        {
            if (string.IsNullOrWhiteSpace(key) || value == null)
            {
                return;
            }

            CacheItemPolicy cacheItemPolicy = CacheHelper.CreateCacheItemPolicy(slidingExpiration, absoluteExpiration, cacheEntryUpdateCallback);

            if (cacheItemPolicy == null)
            {
                return;
            }

            lock (locker)
            {
                CacheItem cacheItem = new CacheItem(key, value);
                MemoryCache.Default.Set(cacheItem, cacheItemPolicy);
            }
        }

        #endregion

        #region Get

        public static object Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            object value = null;

            lock (locker)
            {
                value = MemoryCache.Default[key];
            }

            return value;
        }

        public static T GetValue<T>(string key)
        {
            object value = Get(key);

            if (value == null)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static TModel Get<TModel>(string key) where TModel : class, new()
        {
            object value = Get(key);

            if (value == null)
            {
                return null;
            }

            return value as TModel;
        }

        #endregion

        #region Remove

        public static void Remove(string key)
        {
            lock (locker)
            {
                MemoryCache.Default.Remove(key);
            }
        }

        #endregion
    }
}