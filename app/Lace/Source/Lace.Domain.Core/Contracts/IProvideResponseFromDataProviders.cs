using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Contracts
{
    public interface IProvideResponseFromDataProviders
    {
        IEnumerable<IPointToLaceProvider> Responses { get; set; }
    }
}
