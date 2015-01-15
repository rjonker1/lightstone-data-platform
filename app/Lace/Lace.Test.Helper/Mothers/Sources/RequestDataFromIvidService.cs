
using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Test.Helper.Mothers.Sources
{
    public class RequestDataFromIvidService : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(IProvideResponseFromLaceDataProviders response, ICallTheDataProviderSource externalWebService, ISendCommandsToBus monitoring)
        {
            externalWebService.CallTheDataProvider(response, monitoring);
        }
    }
}
