﻿using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Jis.Infrastructure
{
    public class RequestDataFromJisSource : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(IProvideResponseFromLaceDataProviders response, ICallTheDataProviderSource externalSource,
            ISendMonitoringMessages monitoring)
        {
            externalSource.CallTheDataProvider(response, monitoring);
        }
    }
}
