using Lace.Domain.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IExecuteTheDataProviderSource
    {
        void CallSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring);
    }
}
