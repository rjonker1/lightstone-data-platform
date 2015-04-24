using System.Collections.Generic;
namespace Lace.Domain.DataProviders.Rgt.Core.Contracts
{
    public interface IReadOnlyRepository<T>
    {
        IEnumerable<T> Get(string sql, object param);
    }
}
