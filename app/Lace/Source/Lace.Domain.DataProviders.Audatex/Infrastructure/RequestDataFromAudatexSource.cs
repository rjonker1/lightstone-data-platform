using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure
{
    public class RequestDataFromAudatexSource : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(IProvideResponseFromLaceDataProviders response,
            ICallTheDataProviderSource externalWebService, ISendMonitoringMessages monitoring)
        {
            externalWebService.CallTheExternalSource(response, monitoring);
        }
    }
}
