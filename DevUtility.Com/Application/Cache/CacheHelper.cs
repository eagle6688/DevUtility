using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace DevUtility.Com.Application.Cache
{
    public class CacheHelper
    {
        #region Create CacheItemPolicy

        public static CacheItemPolicy CreateCacheItemPolicy(TimeSpan? slidingExpiration = null, DateTimeOffset? absoluteExpiration = null, CacheEntryUpdateCallback cacheEntryUpdateCallback = null)
        {
            if (slidingExpiration == null && absoluteExpiration == null)
            {
                return null;
            }

            var policy = new CacheItemPolicy();

            if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }
            else if (absoluteExpiration.HasValue)
            {
                policy.AbsoluteExpiration = absoluteExpiration.Value;
            }

            if (cacheEntryUpdateCallback != null)
            {
                policy.UpdateCallback = cacheEntryUpdateCallback;
            }

            policy.Priority = CacheItemPriority.Default;
            return policy;
        }

        #endregion
    }
}