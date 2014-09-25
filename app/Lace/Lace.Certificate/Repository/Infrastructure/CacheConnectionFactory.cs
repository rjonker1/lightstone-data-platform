using System;
using ServiceStack.Redis;

namespace Lace.Certificate.Repository.Infrastructure
{
    public static class CacheConnectionFactory
    {
        private static readonly PooledRedisClientManager LocalClientManager =
            new PooledRedisClientManager("127.0.0.1");

        public static Func<IRedisClient> LocalClient = () => LocalClientManager.GetClient();
    }
}
