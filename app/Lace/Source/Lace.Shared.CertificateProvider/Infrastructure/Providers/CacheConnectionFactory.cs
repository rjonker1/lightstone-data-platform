using System;
using ServiceStack.Redis;

namespace Lace.Shared.CertificateProvider.Infrastructure.Providers
{
    public static class CacheConnectionFactory
    {
        private static readonly PooledRedisClientManager LocalClientManager =
            new PooledRedisClientManager("127.0.0.1");

        public static Func<IRedisClient> LocalClient = () => LocalClientManager.GetClient();
    }
}
