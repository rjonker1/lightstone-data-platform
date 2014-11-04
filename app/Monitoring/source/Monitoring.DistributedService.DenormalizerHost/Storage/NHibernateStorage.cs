using System.Data;
using System.Linq;
using Monitoring.Domain.Core.Contracts;
using NHibernate;
using NHibernate.Linq;

namespace Monitoring.DistributedService.DenormalizerHost.Storage
{
    public class NHibernateStorage : IUpdateStorage
    {
        private readonly ISession _session;
        private ITransaction _transaction;

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
            _session.Save(item);
        }
        public void Update<TItem>(TItem item) where TItem : class
        {
            _session.SaveOrUpdate(item);
        }
        public void Remove<TItem>(TItem item) where TItem : class
        {
            _session.Delete(item);
        }

        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        public void BeginTransaction(IsolationLevel level)
        {
            _transaction = _transaction ?? _session.BeginTransaction(level);
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;
        }
        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();

            _transaction = null;
        }
    }
}
