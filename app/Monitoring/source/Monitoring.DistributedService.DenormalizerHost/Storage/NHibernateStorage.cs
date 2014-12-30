using System.Linq;
using Monitoring.Domain.Core.Contracts;
using NHibernate;
using NHibernate.Linq;

namespace Monitoring.DistributedService.DenormalizerHost.Storage
{
    public class NHibernateStorage : IAccessToStorage
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
        public IQueryable<TItem> Items<TItem>(string sql) where TItem : class
        {
            throw new System.NotImplementedException();
        }
    }
}
