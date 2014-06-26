﻿using Lace.Events;
using Lace.Response;

namespace Lace.Source
{
    public interface IRequestDataFromSource
    {
        void FetchDataFromSource(ILaceResponse response, ICallTheSource externalSource, ILaceEvent laceEvent);
    }
}
