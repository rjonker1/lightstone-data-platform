using System;
using System.Collections.Generic;
using System.Linq;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Domain.Repository
{
    public class MonitoringRepository : IMonitoringRepository
    {
        private readonly IRepositoryMapper _mapper;

        public MonitoringRepository(IRepositoryMapper mapper)
        {
            _mapper = mapper;
        }

        public TType Get<TType>(Guid id) where TType : class
        {
            using (var connection = ConnectionFactoryManager.MonitoringConnection)
            {
                var mapping = _mapper.GetMapping(typeof(TType));
                return mapping.Get(connection, id) as TType;
            }
        }

        public void Add<TType>(TType instance)
        {
            using (var connection = ConnectionFactoryManager.MonitoringConnection)
            {
                var mapping = _mapper.GetMapping(instance);
                mapping.Insert(connection, instance);
            }
        }

        public IEnumerable<TItem> Items<TItem>(string sql) where TItem : class
        {
            using (var connection = ConnectionFactoryManager.MonitoringConnection)
            {
                return connection.Query<TItem>(sql);
            }
        }


        public IEnumerable<TItem> Items<TItem>(string sql, object param) where TItem : class
        {
            using (var connection = ConnectionFactoryManager.MonitoringConnection)
            {
                return connection.Query<TItem>(sql, param);
            }
        }

        public IEnumerable<dynamic> MultipleItems<T1, T2>(string sql)
        {
            using (var connection = ConnectionFactoryManager.MonitoringConnection)
            {
                var results = connection.QueryMultiple(sql);
                var returnResult = new List<dynamic>();
                returnResult.Add(results.Read<T1>().ToList());
                returnResult.Add(results.Read<T2>().ToList());
                return returnResult;

            }
        }

        public IEnumerable<dynamic> MultipleItems<T1, T2, T3>(string sql)
        {
            using (var connection = ConnectionFactoryManager.MonitoringConnection)
            {
                var results = connection.QueryMultiple(sql);
                var returnResult = new List<dynamic>();
                returnResult.Add(results.Read<T1>().ToList());
                returnResult.Add(results.Read<T2>().ToList());
                returnResult.Add(results.Read<T3>().ToList());
                return returnResult;

            }
        }

        public IEnumerable<dynamic> MultipleItems<T1, T2, T3, T4>(string sql)
        {
            using (var connection = ConnectionFactoryManager.MonitoringConnection)
            {
                var results = connection.QueryMultiple(sql);
                var returnResult = new List<dynamic>();
                returnResult.Add(results.Read<T1>().ToList());
                returnResult.Add(results.Read<T2>().ToList());
                returnResult.Add(results.Read<T3>().ToList());
                returnResult.Add(results.Read<T4>().ToList());
                return returnResult;

            }
        }
    }
}