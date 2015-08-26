using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public sealed class RequestDataFromRgtVinSource : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(ICollection<IPointToLaceProvider> response, ICallTheDataProviderSource externalWebService)
        {
            externalWebService.CallTheDataProvider(response);
        }
    }
}
