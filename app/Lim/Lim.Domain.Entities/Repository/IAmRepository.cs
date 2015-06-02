using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace Lim.Domain.Entities.Repository
{
    public interface IAmRepository
    {
        T Get<T>(object id);
        T Find<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        void Save<T>(T entity) where T : class;
        void SaveOrUpdate<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Merge<T>(T entity) where T : class;
        void Flush();
    }

    public class LimRepository : IAmRepository
    {
        private readonly ISession _session;

        public LimRepository(ISession session)
        {
            _session = session;
            _session.FlushMode = FlushMode.Always;
        }

        public T Get<T>(object id)
        {
            return _session.Get<T>(id);
        }

        public T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _session.Query<T>().CacheMode(CacheMode.Refresh).Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _session.Query<T>().CacheMode(CacheMode.Refresh).Where(predicate);
        }

        public void Save<T>(T entity) where T : class
        {
            _session.Save(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _session.Update(entity);
        }

        public void SaveOrUpdate<T>(T entity) where T : class
        {
            _session.SaveOrUpdate(entity);
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _session.Query<T>();
        }
        public void Merge<T>(T entity) where T : class
        {
            _session.Merge(entity);
        }

        public void Flush()
        {
            _session.Flush();
        }
    }
}