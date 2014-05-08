using System;
using System.Collections.Generic;
using Lace.EventHandlers;
using Lace.Operations;
using Lace.Request;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace
{
    public class Initialize : IBootstrap
    {

        public IList<LaceExternalServiceResponse> LaceResponses { get; set; }

        private readonly ILaceRequest _request;
        private Dictionary<Type, Func<ILaceRequest, ILaceResponse>> _handlers;
        private LaceOperation Bootstrap;
        private readonly ILoadRequestSources _loadRequestSources;

        public Initialize(ILaceRequest request, ILoadRequestSources loadRequestSources)
        {
            _request = request;
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
            _handlers = args.Handlers ?? new Dictionary<Type, Func<ILaceRequest, ILaceResponse>>();
        }

        private void LoadSources()
        {
            var args = new LoadEventArgs(_request, _handlers);
            Load(this, args);
            LaceResponses = args.LaceResponses;
        }


        public event EventHandler<LoadEventArgs> Load;
        public event EventHandler<SetHandlersEventArgs> SetHandlers;
       
    }
}
