﻿
using Lace.Domain.Core.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Test.Helper.Mothers.Sources
{
    public class RequestDataFromIvidTitleHolderService : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(IProvideResponseFromLaceDataProviders response, ICallTheDataProviderSource externalWebService, ISendMonitoringMessages monitoring)
        {
            externalWebService.CallTheExternalSource(response, monitoring);
        }
    }
}
