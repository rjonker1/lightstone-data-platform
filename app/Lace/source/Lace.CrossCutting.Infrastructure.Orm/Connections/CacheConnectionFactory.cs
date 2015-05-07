using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Logging;
using ServiceStack.Common.Extensions;
using ServiceStack.Redis;

namespace Lace.CrossCutting.Infrastructure.Orm.Connections
{
    public class CacheConnectionFactory
    {
        private const string CacheIp = "127.0.0.1";

        private static readonly PooledRedisClientManager LocalClientManager =
            new PooledRedisClientManager(CacheIp);

        public static Func<IRedisClient> LocalClient = () => LocalClientManager.GetClient();
    }

    public static class CacheConnectionExtenstions
    {
        private static ILog _log;

        public static bool DoesExistInTheCache(this IEnumerable<dynamic> response)
        {
            _log = LogManager.GetLogger<CacheConnectionFactory>();
            try
            {
                return response != null && response.Any();
            }
            catch (RedisException e)
            {
                _log.ErrorFormat("An error occurred connecting to cache {0}", e, e.Message);
                return false;
            }
            catch (Exception e)
            {
                _log.ErrorFormat("An error occurred connecting to cache {0}",e, e.Message);
                return false;
            }
        }

        public static bool? CanAddItemsToCache(this IEnumerable<dynamic> response)
        {
            try
            {
                return !response.Any();
            }
            catch (RedisException e)
            {
                _log.ErrorFormat("An error occurred connecting to cache {0}",e, e.Message);
                return null;
            }
            catch (Exception e)
            {
                _log.ErrorFormat("An error occurred connecting to cache {0}",e, e.Message);
                return null;
            }
        }

        public static void AddItemsToCache<T>(this T response, IRedisClient connection, string key, DateTime expiresAt) where T : class
        {
            Task.Run(() =>
            {
                _log = LogManager.GetLogger<CacheConnectionFactory>();
                try
                {
                    connection.Add(key, response, expiresAt);
                }
                catch (RedisException e)
                {
                    _log.ErrorFormat("An error occurred adding item to the cache cache {0}",e, e.Message);
                }
                catch (Exception e)
                {
                    _log.ErrorFormat("An error occurred connecting to cache {0}",e, e.Message);
                }
            });
        }
    }
}
