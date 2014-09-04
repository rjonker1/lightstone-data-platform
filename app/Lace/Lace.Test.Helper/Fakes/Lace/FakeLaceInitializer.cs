using System.Collections.Generic;
using Lace.Builder;
using Lace.Events;
using Lace.Request;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace.Test.Helper.Fakes.Lace
{
    public class FakeLaceInitializer: IBootstrap
    {
        public IList<LaceExternalServiceResponse> LaceResponses { get; private set; }

        private readonly ILaceRequest _request;

        private readonly ILaceResponse _response;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly ILaceEvent _laceEvent;

        public FakeLaceInitializer(ILaceResponse response, ILaceRequest request, ILaceEvent laceEvent,
            IBuildSourceChain buildSourceChain)
        {
            _request = request;
            _laceEvent = laceEvent;
            _response = response;
            _buildSourceChain = buildSourceChain;
        }

        public void Execute()
        {
            _buildSourceChain.SourceChain(_request, _laceEvent, _response);

            LaceResponses = new List<LaceExternalServiceResponse>()
            {
                new LaceExternalServiceResponse() {Response = _response}
            };

        }


        //public IList<LaceExternalServiceResponse> LaceResponses { get; set; }
        //private Dictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>> _handlers;

        //private readonly ILaceRequest _request;
        //private readonly ILaceEvent _laceEvent;
        //private readonly ILoadRequestSources _loadRequestSources;

        //public event EventHandler<SetHandlersEventArgs> SetHandlers;
        //public event EventHandler<LoadEventArgs> Load;

        //private LaceOperation Bootstrap;


        //public FakeLaceInitializer(ILaceRequest request, ILoadRequestSources loadRequestSources, ILaceEvent laceEvent)
        //{
        //    _request = request;
        //    _laceEvent = laceEvent;
        //    _loadRequestSources = loadRequestSources;

        //    Set();

        //    InitializeHandlers();

        //    LoadSources();
        //}

        //private void Set()
        //{
        //    Bootstrap = new LaceOperation(_loadRequestSources)
        //    {
        //        LaceBootstrap = this
        //    };
        //}

        //private void InitializeHandlers()
        //{
        //    var args = new SetHandlersEventArgs();
        //    SetHandlers(this, args);
        //    _handlers = args.Handlers ?? new Dictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>>();
        //}

        //private void LoadSources()
        //{
        //    var args = new LoadEventArgs(_request, _handlers, _laceEvent);
        //    Load(this, args);
        //    LaceResponses = args.LaceResponses;
        //}
       
    }
}
