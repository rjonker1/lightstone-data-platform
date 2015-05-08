
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Shared.DataProvider.Repositories
{
    public class DataProviderRepository : IReadOnlyRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRedisClient _cacheClient;

        public DataProviderRepository(IDbConnection connection, IRedisClient cacheClient)
        {
            _connection = connection;
            _cacheClient = cacheClient;
        }

        public IQueryable<TItem> GetAll<TItem>(string sql) where TItem : class
        {
            if (!_cacheClient.ContinueUsingCache())
            {
                return new List<TItem>().AsQueryable();
            }

            var type = _cacheClient.GetTypedClient<TItem>() ?? new RedisTypedClient<TItem>(new RedisClient(CacheConnectionFactory.CacheIp));
            using (type)
            {
                return type.GetAll().AsQueryable();
            }
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            if (!_cacheClient.ContinueUsingCache())
            {
                return _connection.Query<TItem>(sql, param).AsQueryable();
            }

            var type = _cacheClient.GetTypedClient<TItem>() ?? new RedisTypedClient<TItem>(new RedisClient(CacheConnectionFactory.CacheIp));
            using (type)
            {
                if (type.GetAll().Any())
                    return type.GetAll().AsQueryable();

                var dbResponse =
                    _connection.Query<TItem>(sql, param).ToList();

                type.StoreAll(dbResponse);
                return dbResponse.AsQueryable();
            }
        }
    }
}
