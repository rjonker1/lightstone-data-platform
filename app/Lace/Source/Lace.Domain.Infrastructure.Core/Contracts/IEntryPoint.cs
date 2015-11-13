using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface IEntryPoint
    {
        ICollection<IPointToLaceProvider> GetResponsesForCarId(ICollection<IPointToLaceRequest> request);
        ICollection<IPointToLaceProvider> GetResponses(ICollection<IPointToLaceRequest> request);
    }
}
