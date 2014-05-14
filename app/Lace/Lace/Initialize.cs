using System;
using System.Collections.Generic;
using Lace.EventHandlers;
using Lace.Events;
using Lace.Operations;
using Lace.Request;
using Lace.Request.Load;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace
{
    public class Initialize : IBootstrap
    {
        public IList<LaceExternalServiceResponse> LaceResponses { get; set; }

        private readonly ILaceRequest _request;
        private Dictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>> _handlers;
        private LaceOperation Bootstrap;
        private readonly ILoadRequestSources _loadRequestSources;
        private readonly ILaceEvent _laceEvent;

        public Initialize(ILaceRequest request, ILoadRequestSources loadRequestSources, ILaceEvent laceEvent)
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
            var args = new LoadEventArgs(_request, _handlers,_laceEvent);
            Load(this, args);
            LaceResponses = args.LaceResponses;
        }


        public event EventHandler<LoadEventArgs> Load;
        public event EventHandler<SetHandlersEventArgs> SetHandlers;
       
    }
}
