using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ICallTheDataProviderSource
    {
        void CallTheDataProvider(ICollection<IPointToLaceProvider> response, ISendMonitoringCommandsToBus monitoring);
        void TransformResponse(ICollection<IPointToLaceProvider> response, ISendMonitoringCommandsToBus monitoring);
    }
}
