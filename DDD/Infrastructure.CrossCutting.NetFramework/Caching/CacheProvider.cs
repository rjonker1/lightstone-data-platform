
using System;
using System.Configuration;
using System.Runtime.Caching;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Caching
{
    public class CacheProvider
    {
        private static ObjectCache Cache { get { return MemoryCache.Default; }}

        public static object Get(string key)
        {
            return Cache[key];
        }

        public static void Set(string key, object data, int? time = null)
        {
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(time ?? Convert.ToDouble(ConfigurationManager.AppSettings["CacheTime"])) };
            Cache.Add(new CacheItem(key, data), policy);
        }

        public static bool Exist(string key)
        {
            return (Cache.Contains(key));
        }

        public static void Delete(string key)
        {
            Cache.Remove(key);
        }

        public static void Refresh(string key)
        {
            if (Cache.Contains(key))
            {
                var cache = Cache.GetCacheItem(key);
                if (cache != null)
                {
                    var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["SessionTime"])) };
                    Cache.Set(cache, policy);
                }
            }
        }
    }
}