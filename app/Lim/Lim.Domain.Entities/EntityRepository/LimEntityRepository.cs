using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Lim.Domain.Entities.EntityRepository
{
    public class LimEntityRepository : IAmEntityRepository
    {
        private readonly ISession _session;

        public LimEntityRepository(ISession session)
        {
            _session = session;
        }

        public T Get<T>(object id)
        {
            return _session.Get<T>(id);
        }

        public IEnumerable<T> Get<T>(Func<T, bool> predicate) where T : class
        {
            return _session.Query<T>().Where(predicate);
        }

        public void Save<T>(T entity) where T : class
        {
            _session.Save(entity);
        }
    }
}