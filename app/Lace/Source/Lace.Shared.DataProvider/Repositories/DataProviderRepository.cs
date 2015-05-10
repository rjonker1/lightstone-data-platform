using System;
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
        private const string CacheIp = "127.0.0.1:6379";

        public DataProviderRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IQueryable<TItem> GetAll<TItem>(string sql, Func<TItem, bool> predicate) where TItem : class
        {
            try
            {
                using (var manager = new BasicRedisClientManager(CacheIp))
                using (var client = manager.GetClient())
                {
                    var type = client.As<TItem>();
                    return type.GetAll().Where(predicate).AsQueryable();
                }
            }
            catch
            {
            }
            return new List<TItem>().AsQueryable();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param, Func<TItem, bool> predicate) where TItem : class
        {
            using (var manager = new BasicRedisClientManager(CacheIp))
            using (var client = manager.GetClient())
            {
                if (!client.ContinueUsingCache())
                {
                    return _connection.Query<TItem>(sql, param).AsQueryable();
                }

                var type = client.As<TItem>();
                var data = type.GetAll().Where(predicate).ToList();
                return data.Any() ? data.AsQueryable() : _connection.Query<TItem>(sql, param).AsQueryable();
            }
        }

        public IQueryable<TItem> GetAll<TItem>(string sql) where TItem : class
        {
            try
            {
                using (var manager = new BasicRedisClientManager(CacheIp))
                using (var client = manager.GetClient())
                {
                    var type = client.As<TItem>();
                    return type.GetAll().AsQueryable();
                }
            }
            catch
            {
            }
            return new List<TItem>().AsQueryable();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            using (var manager = new BasicRedisClientManager(CacheIp))
            using (var client = manager.GetClient())
            {
                if (!client.ContinueUsingCache())
                {
                    return _connection.Query<TItem>(sql, param).AsQueryable();
                }

                var type = client.As<TItem>();
                return type.GetAll().Any() ? type.GetAll().AsQueryable() : _connection.Query<TItem>(sql, param).AsQueryable();
            }
        }
    }
}