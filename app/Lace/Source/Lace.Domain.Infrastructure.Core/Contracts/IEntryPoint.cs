using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface IEntryPoint
    {
        ICollection<IPointToLaceProvider> GetResponsesFromLace(ILaceRequest request);
    }
}
