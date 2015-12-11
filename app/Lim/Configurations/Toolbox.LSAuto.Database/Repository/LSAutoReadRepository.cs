using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Core;
using NHibernate;
using NHibernate.Linq;
using Toolbox.LSAuto.Entities.Factory;

namespace Toolbox.LightstoneAuto.Repository
{
    public class LsAutoReadRepository : IReadOnlyRepository
    {
        public T Get<T>(object id)
        {
            using (var session = LightstoneAutoFactoryManager.Instance.OpenSession())
                return session.Get<T>(id);
        }

        public T Find<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            using (var session = LightstoneAutoFactoryManager.Instance.OpenSession())
                return session.Query<T>().CacheMode(CacheMode.Refresh).Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> Get<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            using (var session = LightstoneAutoFactoryManager.Instance.OpenSession())
                return session.Query<T>().CacheMode(CacheMode.Refresh).Where(predicate).ToList();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            using (var session = LightstoneAutoFactoryManager.Instance.OpenSession())
                return session.Query<T>().ToList();
        }
    }
}