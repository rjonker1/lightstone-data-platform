
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using ServiceStack.Redis;
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
            using (_cacheClient)
            {
                if (!_cacheClient.ContinueUsingCache())
                {
                    return new List<TItem>().AsQueryable();
                }

                var type = _cacheClient.GetTypedClient<TItem>();
                using (type)
                {
                    return type.GetAll().AsQueryable();
                }
            }
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            using (_cacheClient)
            {
                if (!_cacheClient.ContinueUsingCache())
                {
                    return _connection.Query<TItem>(sql, param).AsQueryable();
                }

                var type = _cacheClient.GetTypedClient<TItem>();

                if (type == null)
                    return _connection.Query<TItem>(sql, param).AsQueryable();


                using (type)
                {
                    return type.GetAll().Any() ? type.GetAll().AsQueryable() : _connection.Query<TItem>(sql, param).AsQueryable();

                    //var dbResponse =
                    //    _connection.Query<TItem>(sql, param).ToList();

                    //type.StoreAll(dbResponse);
                    //return dbResponse.AsQueryable();
                }
            }
        }
    }
}
