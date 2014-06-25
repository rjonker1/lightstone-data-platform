using System;
using System.Collections.Generic;
using Lace.Builder;
using Lace.Events;
using Lace.Request;
using Lace.Response;
using Lace.Response.ExternalServices;
using Monitoring.Sources.Lace;

namespace Lace
{
    public class Initialize : IBootstrap
    {
        public IList<LaceExternalServiceResponse> LaceResponses { get; private set; }

        private readonly ILaceRequest _request;

        private readonly ILaceResponse _response;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly ILaceEvent _laceEvent;

        public Initialize(ILaceResponse response, ILaceRequest request, ILaceEvent laceEvent,
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

            _laceEvent.PublishLaceProcessedRequestAndReturnedResponseMessage(_request.RequestAggregation.AggregateId,
                LaceEventSource.Initialization);
        }
    }
}
