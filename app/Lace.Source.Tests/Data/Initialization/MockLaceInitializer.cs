using System;
using System.Collections.Generic;
using Lace.EventHandlers;
using Lace.Request;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace.Source.Tests.Data.Initialization
{
    public class MockLaceInitializer : IBootstrap
    {
        public IList<LaceExternalServiceResponse> LaceResponses { get; set; }

        public event EventHandler<SetHandlersEventArgs> SetHandlers;
        public event EventHandler<LoadEventArgs> Load;

        public Dictionary<Type, Func<ILaceRequest, ILaceResponse>> SetTheExternalSourceHandlers()
        {
            if (SetHandlers == null) return null;

            var args = new SetHandlersEventArgs();
            SetHandlers(this, args);
            return args.Handlers;

        }

        public void LoadTheExternalSourceHandlers(ILaceRequest request, Dictionary<Type, Func<ILaceRequest, ILaceResponse>> handlers)
        {
            if (Load == null) return;

            var args = new LoadEventArgs(request, handlers);
            Load(this, args);
            LaceResponses = args.LaceResponses;
        }
    }
}
