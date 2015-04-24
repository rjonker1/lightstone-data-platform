using System.Collections.Generic;

namespace Lace.Domain.DataProviders.Lightstone.Core
{
    public interface IReadOnlyRepository<T>
    {
        IEnumerable<T> Get(string sql, object param);
        IEnumerable<T> GetAll(string sql);
    }
}
