using System;
using System.Runtime.Caching;

namespace DevUtility.Com.Application.Cache
{
    public class MemoryCacheHelper
    {
        #region Set

        public static bool Set(string key, object value)
        {
            CacheItemPolicy cacheItemPolicy = CreateCacheItemPolicy();
            return Set(key, value, cacheItemPolicy);
        }

        public static bool Set(string key, object value, DateTimeOffset absoluteExpiration, CacheEntryUpdateCallback cacheEntryUpdateCallback)
        {
            CacheItemPolicy cacheItemPolicy = CreateCacheItemPolicy(absoluteExpiration, cacheEntryUpdateCallback);
            return Set(key, value, cacheItemPolicy);
        }

        public static bool Set(string key, object value, TimeSpan slidingExpiration, CacheEntryUpdateCallback cacheEntryUpdateCallback)
        {
            CacheItemPolicy cacheItemPolicy = CreateCacheItemPolicy(slidingExpiration, cacheEntryUpdateCallback);
            return Set(key, value, cacheItemPolicy);
        }

        public static bool Set(string key, object value, CacheItemPolicy cacheItemPolicy)
        {
            if (string.IsNullOrEmpty(key) || value == null)
            {
                return false;
            }

            CacheItem cacheItem = new CacheItem(key, value);
            MemoryCache.Default.Set(cacheItem, cacheItemPolicy);
            return true;
        }

        #endregion

        #region Get

        public static object Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            if (!MemoryCache.Default.Contains(key))
            {
                return null;
            }

            return MemoryCache.Default[key];
        }

        public static T Get<T>(string key)
        {
            object value = Get(key);

            if (value == null)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }

        #endregion

        #region Remove

        public static void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        #endregion

        #region Create CacheItemPolicy

        private static CacheItemPolicy CreateCacheItemPolicy()
        {
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.Priority = CacheItemPriority.NotRemovable;
            return cacheItemPolicy;
        }

        private static CacheItemPolicy CreateCacheItemPolicy(TimeSpan slidingExpiration)
        {
            return CreateCacheItemPolicy(slidingExpiration, null);
        }

        private static CacheItemPolicy CreateCacheItemPolicy(TimeSpan slidingExpiration, CacheEntryUpdateCallback cacheEntryUpdateCallback)
        {
            if (slidingExpiration == TimeSpan.MinValue)
            {
                return CreateCacheItemPolicy();
            }

            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.Priority = CacheItemPriority.Default;
            cacheItemPolicy.SlidingExpiration = slidingExpiration;

            if (cacheEntryUpdateCallback != null)
            {
                cacheItemPolicy.UpdateCallback = cacheEntryUpdateCallback;
            }

            return cacheItemPolicy;
        }

        private static CacheItemPolicy CreateCacheItemPolicy(DateTimeOffset absoluteExpiration)
        {
            return CreateCacheItemPolicy(absoluteExpiration, null);
        }

        private static CacheItemPolicy CreateCacheItemPolicy(DateTimeOffset absoluteExpiration, CacheEntryUpdateCallback cacheEntryUpdateCallback)
        {
            if (absoluteExpiration == null)
            {
                return CreateCacheItemPolicy();
            }

            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.Priority = CacheItemPriority.Default;
            cacheItemPolicy.AbsoluteExpiration = absoluteExpiration;

            if (cacheEntryUpdateCallback != null)
            {
                cacheItemPolicy.UpdateCallback = cacheEntryUpdateCallback;
            }

            return cacheItemPolicy;
        }

        #endregion
    }
}