﻿using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;


namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure
{
    public class RequestDatafromIvidTitleHolderSource : IRequestDataFromDataProviderSource
    {
        public void FetchDataFromSource(ICollection<IPointToLaceProvider> response,
            ICallTheDataProviderSource externalSource)
        {
            externalSource.CallTheDataProvider(response);
        }
    }
}
