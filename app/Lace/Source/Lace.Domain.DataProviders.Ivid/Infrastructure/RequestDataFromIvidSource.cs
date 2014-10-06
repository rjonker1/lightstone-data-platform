using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure
{
    public class RequestDataFromIvidSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(IProvideLaceResponse response, ICallTheSource externalSource,
            ILaceEvent laceEvent)
        {
            externalSource.CallTheExternalSource(response, laceEvent);
        }
    }
}
