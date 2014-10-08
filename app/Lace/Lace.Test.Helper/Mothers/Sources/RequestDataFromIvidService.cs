using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Test.Helper.Mothers.Sources
{
    public class RequestDataFromIvidService : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(IProvideResponseFromLaceDataProviders response, ICallTheDataProviderSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalSource(response,laceEvent);
        }
    }
}
