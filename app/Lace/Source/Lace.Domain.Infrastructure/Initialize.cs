using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Monitoring.Sources.Lace;

namespace Lace.Domain.Infrastructure.EntryPoint
{
    internal class Initialize : IBootstrap
    {
        public IList<LaceExternalSourceResponse> LaceResponses { get; private set; }
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        private readonly ILaceRequest _request;

        private readonly IProvideLaceResponse _response;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly ILaceEvent _laceEvent;

        public Initialize(IProvideLaceResponse response, ILaceRequest request, ILaceEvent laceEvent,
            IBuildSourceChain buildSourceChain)
        {
            _request = request;
            _laceEvent = laceEvent;
            _response = response;
            _buildSourceChain = buildSourceChain;
        }


        public void Execute()
        {
            if (_buildSourceChain.SourceChain == null)
            {
                Log.Error("Source chain for request is null and cannot be executed");
                throw new Exception("Source Chain cannot be null");
            }


            _buildSourceChain.SourceChain(_request, _laceEvent, _response);

            LaceResponses = new List<LaceExternalSourceResponse>()
            {
                new LaceExternalSourceResponse() {Response = _response}
            };

            _laceEvent.PublishLaceProcessedRequestAndReturnedResponseMessage(LaceEventSource.Initialization);
        }
    }
}
