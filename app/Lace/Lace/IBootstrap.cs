using System;
using System.Collections.Generic;
using Lace.EventHandlers;
using Lace.Response.ExternalServices;

namespace Lace
{
    public interface IBootstrap
    {
        IList<LaceExternalServiceResponse> LaceResponses { get; set; }

        event EventHandler<SetHandlersEventArgs> SetHandlers;
        event EventHandler<LoadEventArgs> Load;
    }
}