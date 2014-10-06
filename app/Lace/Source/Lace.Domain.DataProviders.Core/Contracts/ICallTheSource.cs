using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ICallTheSource
    {
        void CallTheExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent);
        void TransformResponse(IProvideLaceResponse response);
    }
}
