using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.DataProviders.Rgt.Core.Contracts
{
    public interface IReadOnlyRepository<T>
    {
        IEnumerable<T> FindWithRequest(IHaveCarInformation request);
    }
}
