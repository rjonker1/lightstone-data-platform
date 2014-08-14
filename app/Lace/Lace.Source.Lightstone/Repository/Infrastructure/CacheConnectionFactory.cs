using System;
using ServiceStack.Redis;

namespace Lace.Source.Lightstone.Repository.Infrastructure
{
    public static class CacheConnectionFactory
    {
        private static readonly PooledRedisClientManager PooledLocalClientManager =
            new PooledRedisClientManager("localhost");

        public static Func<IRedisClient> LocalClient = () => PooledLocalClientManager.GetClient();
    }
}
