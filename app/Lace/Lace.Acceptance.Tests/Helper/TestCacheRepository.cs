using ServiceStack.Redis;

namespace Lace.Acceptance.Tests.Helper
{
    public class TestCacheRepository
    {
        private const string CacheIp = "127.0.0.1:6379";

        public static void ClearAll()
        {
            using (var client = new RedisClient(CacheIp))
            {
                client.FlushDb();
                client.FlushAll();
            }
        }
    }
}
