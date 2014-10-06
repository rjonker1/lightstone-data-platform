using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure
{
    public class RequestDataFromAudatexSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(IProvideLaceResponse response,
            ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalSource(response, laceEvent);
        }
    }
}
