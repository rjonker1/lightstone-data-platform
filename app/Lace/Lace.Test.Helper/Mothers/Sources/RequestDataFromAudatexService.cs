
using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Test.Helper.Mothers.Sources
{
    public class RequestDataFromAudatexService : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(IProvideResponseFromLaceDataProviders response, ICallTheDataProviderSource externalWebService, ISendMonitoringCommandsToBus monitoring)
        {
            externalWebService.CallTheDataProvider(response, monitoring);
        }
    }
}
