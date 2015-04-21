using System.Collections.Generic;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmDataProviderRequest
    {
        IEnumerable<IAmRequestField> RequestFields { get; }
    }
}