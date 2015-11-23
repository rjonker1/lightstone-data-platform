using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ICallTheDataProviderSource
    {
        void CallTheDataProvider(ICollection<IPointToLaceProvider> response);
        void TransformResponse(ICollection<IPointToLaceProvider> response);
    }
}
