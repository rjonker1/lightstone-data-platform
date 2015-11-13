using System.Linq;
using EventTracking.Domain.Core.Contracts;
using NHibernate;
using NHibernate.Linq;

namespace EventTracking.Host.Denormalizer.Storage
{
    public class NHibernateStorage : IUpdateStorage
    {
        private readonly ISession _session;
        public NHibernateStorage(ISession session)
        {
            _session = session;
        }

        public IQueryable<TItem> Items<TItem>() where TItem : class
        {
            return _session.Query<TItem>();
        }

        public void Add<TItem>(TItem item) where TItem : class
        {
            using (var trans = _session.BeginTransaction())
            {
                _session.Save(item);
                trans.Commit();
            }
        }

        public void Update<TItem>(TItem item) where TItem : class
        {
            using (var trans = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(item);
                trans.Commit();
            }
        }
        public void Remove<TItem>(TItem item) where TItem : class
        {
            using (var trans = _session.BeginTransaction())
            {
                _session.Delete(item);
                trans.Commit();
            }
        }
    }
}
