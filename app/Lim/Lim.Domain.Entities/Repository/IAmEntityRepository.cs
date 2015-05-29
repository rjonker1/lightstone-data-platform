using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Lim.Domain.Entities.Repository
{
    public interface IAmEntityRepository
    {
        T Get<T>(object id);
        IEnumerable<T> Get<T>(Func<T, bool> predicate) where T : class;
        void Save<T>(T entity) where T : class;
        void SaveOrUpdate<T>(T entity) where T : class;
    }

    public class LimEntityRepository : IAmEntityRepository
    {
        private readonly ISession _session;

        public LimEntityRepository(ISession session)
        {
            _session = session;
            _session.FlushMode = FlushMode.Always;
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

        public void SaveOrUpdate<T>(T entity) where T : class
        {
            _session.SaveOrUpdate(entity);
        }
    }
}