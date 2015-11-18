using System;
using System.Collections.Generic;
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
    }
}