using System;
using System.Collections.Generic;
using Lace.EventHandlers;
using Lace.Events;
using Lace.Operations;
using Lace.Request;
using Lace.Request.Load;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace.Test.Helper.Fakes.Lace
{
    public class FakeLaceInitializer: IBootstrap
    {
        public IList<LaceExternalServiceResponse> LaceResponses { get; set; }
        private Dictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>> _handlers;

        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private readonly ILoadRequestSources _loadRequestSources;

        public event EventHandler<SetHandlersEventArgs> SetHandlers;
        public event EventHandler<LoadEventArgs> Load;

        private LaceOperation Bootstrap;


        public FakeLaceInitializer(ILaceRequest request, ILoadRequestSources loadRequestSources, ILaceEvent laceEvent)
        {
            _request = request;
            _laceEvent = laceEvent;
            _loadRequestSources = loadRequestSources;

            Set();

            InitializeHandlers();

            LoadSources();
        }

        private void Set()
        {
            Bootstrap = new LaceOperation(_loadRequestSources)
            {
                LaceBootstrap = this
            };
        }

        private void InitializeHandlers()
        {
            var args = new SetHandlersEventArgs();
            SetHandlers(this, args);
            _handlers = args.Handlers ?? new Dictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>>();
        }

        private void LoadSources()
        {
            var args = new LoadEventArgs(_request, _handlers, _laceEvent);
            Load(this, args);
            LaceResponses = args.LaceResponses;
        }
    }
}
