using System;
using System.Data;
using System.Linq;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Monitoring.Domain.Repository
{
    public class MonitoringRepository : IMonitoringRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRepositoryMapper _mapper;

        public MonitoringRepository(IDbConnection connection, IRepositoryMapper mapper)
        {
            _mapper = mapper;
            _connection = connection;
        }

        public TType Get<TType>(Guid id) where TType : class
        {
            var mapping = _mapper.GetMapping(typeof (TType));

            return mapping.Get(_connection, id) as TType;

        }

        public void Add<TType>(TType instance)
        {
            var mapping = _mapper.GetMapping(instance);

            mapping.Insert(_connection, instance);
        }

        public IQueryable<TItem> Items<TItem>(string sql) where TItem : class
        {
            return _connection.Query<TItem>(sql).ToList().AsQueryable();
        }
    }
}
