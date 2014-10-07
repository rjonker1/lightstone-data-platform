using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IExecuteTheDataProviderSource
    {
        void CallSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent);
    }
}
