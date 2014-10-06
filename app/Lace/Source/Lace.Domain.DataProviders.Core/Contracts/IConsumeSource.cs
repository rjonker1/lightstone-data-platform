using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IConsumeSource
    {
        void ConsumeExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent);
    }
}
