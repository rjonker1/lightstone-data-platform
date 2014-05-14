using System;
using System.Collections.Generic;
using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.EventHandlers
{
    public class SetHandlersEventArgs : EventArgs
    {
        public Dictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>> Handlers { get; set; }

        public SetHandlersEventArgs()
        {
            Handlers = new Dictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>>();
        }
    }
}
