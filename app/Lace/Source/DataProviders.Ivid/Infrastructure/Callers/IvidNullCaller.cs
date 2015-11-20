using System.Collections.Generic;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Callers
{
    public class IvidNullCaller : ICallTheDataProviderSource
    {
        public void CallTheDataProvider(ICollection<Domain.Core.Contracts.Requests.IPointToLaceProvider> response)
        {
            
        }

        public void TransformResponse(ICollection<Domain.Core.Contracts.Requests.IPointToLaceProvider> response)
        {
           
        }
    }
}
