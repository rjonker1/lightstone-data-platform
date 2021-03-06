﻿using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.PCubed.EzScore.Infrastructure
{
    public class RequestDataFromPCubedEzScore : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(ICollection<IPointToLaceProvider> response, ICallTheDataProviderSource externalSource)
        {
            externalSource.CallTheDataProvider(response);
        }
    }
}