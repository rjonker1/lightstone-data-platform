﻿using Lace.Events;
using Lace.Models;

namespace Lace.Source.Ivid.ServiceCalls
{
    public class RequestDataFromIvidSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(IProvideLaceResponse response, ICallTheSource externalSource,
            ILaceEvent laceEvent)
        {
            externalSource.CallTheExternalSource(response, laceEvent);
        }
    }
}
