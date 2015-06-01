using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using ServiceStack.Redis;

namespace Lim.Test.Api.Data
{
    public interface IRepository
    {
        void Persist<T>(T item) where T : class;
        T Get<T>(Func<T, bool> predicate) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        void Delete<T>();
    }

    public class Repository : IRepository
    {
        private const string Ip = "127.0.0.1:6379";
        private readonly ILog _log;

        public Repository()
        {
            _log = LogManager.GetLogger(GetType());
        }

        public void Persist<T>(T item) where T : class
        {
            try
            {
                using (var manager = new PooledRedisClientManager(1000, 10, new[] {Ip}) {ConnectTimeout = 1000})
                using (var redis = manager.GetClient())
                {
                    var type = redis.As<T>();
                    type.Store(item);
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot add item to repository because of {0}", ex, ex.Message);
            }
        }

        public T Get<T>(Func<T, bool> predicate) where T : class
        {
            try
            {
                using (var manager = new BasicRedisClientManager(Ip))
                using (var client = manager.GetClient())
                {
                    return client.GetTypedClient<T>().GetAll().Where(predicate).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot add item to repository because of {0}", ex, ex.Message);
            }
            return null;
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            try
            {
                using (var manager = new BasicRedisClientManager(Ip))
                using (var client = manager.GetClient())
                {
                    return client.GetTypedClient<T>().GetAll();
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot add item to repository because of {0}", ex, ex.Message);
            }

            return Enumerable.Empty<T>();
        }


        public void Delete<T>()
        {
            try
            {
                using (var manager = new PooledRedisClientManager(1000, 10, new[] { Ip }) { ConnectTimeout = 1000 })
                using (var redis = manager.GetClient())
                {
                    redis.As<T>().DeleteAll();
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Cannot add item to repository because of {0}", ex, ex.Message);
            }
        }
    }
}