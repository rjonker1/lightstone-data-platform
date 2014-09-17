﻿using Lace.Events;
using Lace.Models;
using Lace.Source;

namespace Lace.Test.Helper.Mothers.Sources
{
    public class RequestDataFromRgtVinHolderSource : IRequestDataFromSource
    {
        public void FetchDataFromSource(IProvideLaceResponse response, ICallTheSource externalWebService, ILaceEvent laceEvent)
        {
            externalWebService.CallTheExternalSource(response, laceEvent);
        }
    }
}
