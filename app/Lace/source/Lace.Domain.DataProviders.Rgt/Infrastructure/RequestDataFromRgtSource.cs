using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure
{
    public class RequestDataFromRgtSource : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(IProvideResponseFromLaceDataProviders response, ICallTheDataProviderSource externalSource, ISendCommandsToBus monitoring)
        {
            externalSource.CallTheDataProvider(response,monitoring);
        }
    }
}
