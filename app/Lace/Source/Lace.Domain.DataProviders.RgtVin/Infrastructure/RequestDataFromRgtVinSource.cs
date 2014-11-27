using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public class RequestDataFromRgtVinSource : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(IProvideResponseFromLaceDataProviders response, ICallTheDataProviderSource externalWebService, ISendMonitoringMessages monitoring)
        {
            externalWebService.CallTheDataProvider(response, monitoring);
        }
    }
}
