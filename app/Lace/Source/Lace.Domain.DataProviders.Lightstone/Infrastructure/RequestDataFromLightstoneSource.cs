using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure
{
    public class RequestDataFromLightstoneSource : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(ICollection<IPointToLaceProvider> response, ICallTheDataProviderSource externalSource, ISendMonitoringCommandsToBus monitoring)
        {
            externalSource.CallTheDataProvider(response, monitoring);
        }
    }
}
