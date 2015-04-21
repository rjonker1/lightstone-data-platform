using System.Collections.Generic;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmRequest
    {
        IEnumerable<IAmRequestField> RequestFields { get; }
    }
}