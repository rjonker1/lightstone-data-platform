using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using ServiceStack.Redis;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Lace.Shared.DataProvider.Repositories
{
    public class DataProviderRepository : IReadOnlyRepository
    {
        private readonly IDbConnection _connection;
        private const string CacheIp = "127.0.0.1:6379";
        private readonly ILog _log;

        public DataProviderRepository(IDbConnection connection)
        {
            _connection = connection;
            _log = LogManager.GetLogger(GetType());
        }

        public IQueryable<TItem> GetAll<TItem>(Func<TItem, bool> predicate) where TItem : class
        {
            try
            {
                using (var manager = new BasicRedisClientManager(CacheIp))
                using (var client = manager.GetClient())
                {
                    return predicate != null
                        ? client.GetTypedClient<TItem>().GetAll().Where(predicate).AsQueryable()
                        : client.GetTypedClient<TItem>().GetAll().AsQueryable();
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Could not get items from the cache because of {0}", ex.Message, ex);
            }
            return new List<TItem>().AsQueryable();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            try
            {
                return _connection.Query<TItem>(sql, param).AsQueryable();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Could not get items from database because of {0}", ex.Message, ex);
            }

            return new List<TItem>().AsQueryable();
        }

        //private IQueryable<TItem> GetFromDataBase<TItem>(string sql, object param) where TItem : class
        //{
        //    try
        //    {
        //        return _connection.Query<TItem>(sql, param).AsQueryable();
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.ErrorFormat("Could not get items from database because of {0}", ex.Message, ex);
        //    }

        //    return new List<TItem>().AsQueryable();
        //}

        //public IQueryable<TItem> GetAll<TItem>(string sql) where TItem : class
        //{
        //    try
        //    {
        //        using (var manager = new BasicRedisClientManager(CacheIp))
        //        using (var client = manager.GetClient())
        //        {
        //            var type = client.As<TItem>();
        //            return type.GetAll().AsQueryable();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.ErrorFormat("Could not get items from the cache because of {0}", ex.Message, ex);
        //    }
        //    return new List<TItem>().AsQueryable();
        //}

        //public IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class
        //{
        //    using (var manager = new BasicRedisClientManager(CacheIp))
        //    using (var client = manager.GetClient())
        //    {
        //        if (!client.ContinueUsingCache())
        //        {
        //            return _connection.Query<TItem>(sql, param).AsQueryable();
        //        }

        //        var type = client.As<TItem>();
        //        return type.GetAll().Any() ? type.GetAll().AsQueryable() : _connection.Query<TItem>(sql, param).AsQueryable();
        //    }
        //}
    }
}