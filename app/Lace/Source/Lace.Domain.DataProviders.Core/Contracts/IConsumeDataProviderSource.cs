using Lace.Domain.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IConsumeDataProviderSource
    {
        void ConsumeExternalSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring);
    }
}
