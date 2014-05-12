using System;
using System.Collections.Generic;
using Lace.EventHandlers;
using Lace.Operations;
using Lace.Request;
using Lace.Request.Load;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace.Source.Tests.Data.Initialization
{
    public class MockLaceInitializer : IBootstrap
    {
        public IList<LaceExternalServiceResponse> LaceResponses { get; set; }
        private Dictionary<Type, Func<ILaceRequest, ILaceResponse>> _handlers;

        private readonly ILaceRequest _request;
        private readonly ILoadRequestSources _loadRequestSources;

        public event EventHandler<SetHandlersEventArgs> SetHandlers;
        public event EventHandler<LoadEventArgs> Load;

        private LaceOperation Bootstrap;


        public MockLaceInitializer(ILaceRequest request, ILoadRequestSources loadRequestSources)
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
    }
}
