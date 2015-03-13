using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface IRequestDataFromDataProviderSource
    {
        void FetchDataFromSource(ICollection<IPointToLaceProvider> response, ICallTheDataProviderSource externalSource, ISendMonitoringCommandsToBus monitoring);
    }
}
