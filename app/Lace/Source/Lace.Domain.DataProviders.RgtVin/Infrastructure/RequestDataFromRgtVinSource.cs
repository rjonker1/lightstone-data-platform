﻿using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public class RequestDataFromRgtVinSource : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(IProvideResponseFromLaceDataProviders response, ICallTheDataProviderSource externalWebService, ISendMonitoringCommandsToBus monitoring)
        {
            externalWebService.CallTheDataProvider(response, monitoring);
        }
    }
}
