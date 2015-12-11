using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Core;
using NHibernate;
using NHibernate.Linq;
using Toolbox.LSAuto.Entities.Factory;

namespace Lim.Test.Helper.Database.Repositories
{
    public class InMemoryLsAutoRepository :  IReadOnlyRepository
    {
        private readonly ISession _session;
        public InMemoryLsAutoRepository()
        {
            _session = LightstoneAutoInMemoryFactoryManager.Instance.OpenSession();
        }

        public T Get<T>(object id)
        {
            return _session.Get<T>(id);
        }

        public T Find<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            return _session.Query<T>().CacheMode(CacheMode.Refresh).Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> Get<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            return _session.Query<T>().CacheMode(CacheMode.Refresh).Where(predicate).ToList();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _session.Query<T>().ToList();
        }
    }
}
