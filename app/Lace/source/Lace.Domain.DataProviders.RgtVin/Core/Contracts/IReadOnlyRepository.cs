using System.Collections.Generic;

namespace Lace.Domain.DataProviders.RgtVin.Core.Contracts
{
    public interface IReadOnlyRepository<T>
    {
        IEnumerable<T> FindWith(string vin);
    }
}
