using Lace.Domain.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ICallTheDataProviderSource
    {
        void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring);
        void TransformResponse(IProvideResponseFromLaceDataProviders response);
    }
}
