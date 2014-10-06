using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IRequestDataFromSource
    {
        void FetchDataFromSource(IProvideLaceResponse response, ICallTheSource externalSource, ILaceEvent laceEvent);
    }
}
