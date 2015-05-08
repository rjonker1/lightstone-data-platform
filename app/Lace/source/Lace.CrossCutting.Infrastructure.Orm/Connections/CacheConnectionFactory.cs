using System;
using Common.Logging;
using ServiceStack.Redis;

namespace Lace.CrossCutting.Infrastructure.Orm.Connections
{
    public class CacheConnectionFactory
    {
        public const string CacheIp = "127.0.0.1";

        private static readonly PooledRedisClientManager LocalClientManager =
            new PooledRedisClientManager(CacheIp);
       

        public static Func<IRedisClient> LocalClient = () => new RedisClient(CacheIp);
    }

    public static class CacheConnectionExtenstions
    {
        private static readonly ILog Log = LogManager.GetLogger<CacheConnectionFactory>();

        public static bool ContinueUsingCache(this IRedisClient client)
        {
            try
            {
                var check = client.DbSize;
                return true;
            }
            catch (RedisException e)
            {
                Log.ErrorFormat("Could not connect to cache {0}", e, e.Message);
                return false;
            }
            catch (Exception e)
            {
                Log.ErrorFormat("Could not connect connecting to cache {0}", e, e.Message);
                return false;
            }
        }
    }
}
