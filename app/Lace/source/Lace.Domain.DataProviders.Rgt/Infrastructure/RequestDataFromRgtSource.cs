﻿using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure
{
    public class RequestDataFromRgtSource : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(IProvideResponseFromLaceDataProviders response, ICallTheDataProviderSource externalSource, ISendMonitoringMessages monitoring)
        {
            externalSource.CallTheExternalSource(response,monitoring);
        }
    }
}
