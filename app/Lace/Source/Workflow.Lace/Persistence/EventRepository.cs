using System;
using System.Collections.Generic;
using System.Linq;
using Shared.BuildingBlocks.AdoNet.Repository;

namespace Workflow.Lace.Persistence
{
    public class EventRepository : IEventRepository
    {
        private readonly IRepositoryMapper _mapper;

        public EventRepository(IRepositoryMapper mapper)
        {
            _mapper = mapper;
        }

        public void Add<TType>(TType instance)
        {
            using (var connection = PersistenceManager.Connection)
            {
                var mapping = _mapper.GetMapping(instance);
                mapping.Insert(connection, instance);
            }
        }

        public TType Get<TType>(Guid id) where TType : class
        {
            using (var connection = PersistenceManager.Connection)
            {
                var mapping = _mapper.GetMapping(typeof (TType));
                return mapping.Get(connection, id) as TType;
            }
        }

        public IList<TItem> Items<TItem>(string sql) where TItem : class
        {
            using (var connection = PersistenceManager.Connection)
            {
                return connection.Query<TItem>(sql).ToList();
            }
        }

        public IList<TItem> Items<TItem>(string sql, object param) where TItem : class
        {
            using (var connection = PersistenceManager.Connection)
            {
                return connection.Query<TItem>(sql, param).ToList();
            }
        }

        public TItem Item<TItem>(string sql, object param) where TItem : class
        {
            using (var connection = PersistenceManager.Connection)
            {
                return connection.Query<TItem>(sql, param).FirstOrDefault();
            }

        }
    }
}
