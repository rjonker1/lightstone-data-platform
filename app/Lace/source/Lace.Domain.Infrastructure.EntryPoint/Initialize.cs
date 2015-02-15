using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using NServiceBus;

namespace Lace.Domain.Infrastructure.EntryPoint
{
    public class Initialize : IBootstrap
    {
        public IList<LaceExternalSourceResponse> LaceResponses { get; private set; }
        private readonly ILog _log;
        private readonly ILaceRequest _request;

        private readonly IProvideResponseFromLaceDataProviders _response;

        private readonly IBuildSourceChain _buildSourceChain;

        private readonly IBus _bus;

        public Initialize(IProvideResponseFromLaceDataProviders response, ILaceRequest request, IBus bus,
            IBuildSourceChain buildSourceChain)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _bus = bus;
            _response = response;
            _buildSourceChain = buildSourceChain;
        }


        public void Execute()
        {
            if (_buildSourceChain.SourceChain == null)
            {
                _log.Error("Source chain for request is null and cannot be executed");
                throw new Exception("Source Chain cannot be null");
            }

            _buildSourceChain.SourceChain(_request, _bus, _response, _request.RequestAggregation.AggregateId);

            LaceResponses = new List<LaceExternalSourceResponse>()
            {
                new LaceExternalSourceResponse() {Response = _response}
            };
        }
    }
}
