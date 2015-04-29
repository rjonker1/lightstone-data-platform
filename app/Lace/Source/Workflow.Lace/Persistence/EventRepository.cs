using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Workflow.Lace.Persistence
{
    public class EventRepository : IEventRepository
    {
        private readonly IDbConnection _connection;
        private readonly IRepositoryMapper _mapper;

        public EventRepository(IDbConnection connection, IRepositoryMapper mapper)
        {
            _mapper = mapper;
            _connection = connection;
        }

        public void Add<TType>(TType instance)
        {
            var mapping = _mapper.GetMapping(instance);
            mapping.Insert(_connection, instance);
        }

        public TType Get<TType>(Guid id) where TType : class
        {
            var mapping = _mapper.GetMapping(typeof (TType));
            return mapping.Get(_connection, id) as TType;
        }

        public IList<TItem> Items<TItem>(string sql) where TItem : class
        {
            return _connection.Query<TItem>(sql).ToList();
        }

        public IList<TItem> Items<TItem>(string sql, object param) where TItem : class
        {
            return _connection.Query<TItem>(sql, param).ToList();
        }

        public TItem Item<TItem>(string sql, object param) where TItem : class
        {
            return _connection.Query<TItem>(sql, param).FirstOrDefault();
            
        }
    }
}
