using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure
{
    public class RequestDatafromIvidTitleHolderSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(IProvideLaceResponse response,
            ICallTheSource externalSource, ILaceEvent laceEvent)
        {
            externalSource.CallTheExternalSource(response, laceEvent);
        }
    }
}
