using System.Collections.Generic;
using Lace.Builder;
using Lace.Events;
using Lace.Models;
using Lace.Request;
using Lace.Response.ExternalServices;

namespace Lace.Test.Helper.Fakes.Lace
{
    public class FakeLaceInitializer: IBootstrap
    {
        public IList<LaceExternalSourceResponse> LaceResponses { get; private set; }

        private readonly ILaceRequest _request;

        private readonly IProvideLaceResponse _response;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly ILaceEvent _laceEvent;

        public FakeLaceInitializer(IProvideLaceResponse response, ILaceRequest request, ILaceEvent laceEvent,
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

            LaceResponses = new List<LaceExternalSourceResponse>()
            {
                new LaceExternalSourceResponse() {Response = _response}
            };

        }
    }
}
