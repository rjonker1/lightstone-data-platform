using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;


namespace Lace.Domain.DataProviders.Audatex.Infrastructure
{
    public class RequestDataFromAudatexSource : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(ICollection<IPointToLaceProvider> response,
            ICallTheDataProviderSource externalWebService)
        {
            externalWebService.CallTheDataProvider(response);
        }
    }
}
