using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ICallTheDataProviderSource
    {
        void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent);
        void TransformResponse(IProvideResponseFromLaceDataProviders response);
    }
}
