using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IConsumeDataProviderSource
    {
        void ConsumeExternalSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent);
    }
}
