using System;
using System.Collections.Generic;

namespace Lim.Domain.Entities.EntityRepository
{
    public interface IAmEntityRepository
    {
        T Get<T>(object id);
        IEnumerable<T> Get<T>(Func<T, bool> predicate) where T : class;
        void Save<T>(T entity) where T : class;
    }
}
