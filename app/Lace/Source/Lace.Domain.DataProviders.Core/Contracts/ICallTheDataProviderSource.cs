using Lace.Domain.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ICallTheDataProviderSource
    {
        void CallTheDataProvider(IProvideResponseFromLaceDataProviders response, ISendMonitoringCommandsToBus monitoring);
        void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendMonitoringCommandsToBus monitoring);
    }
}
