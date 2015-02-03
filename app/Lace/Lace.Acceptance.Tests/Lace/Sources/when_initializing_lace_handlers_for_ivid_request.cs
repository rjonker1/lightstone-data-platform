using System;
using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using NServiceBus;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_ivid_request : Specification
    {
        private readonly ILaceRequest _request;
        private readonly IBus _monitoring;
        private readonly IBootstrap _initialize;
        private IList<LaceExternalSourceResponse> _laceResponses;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_initializing_lace_handlers_for_ivid_request()
        {
            _monitoring = BusFactory.NServiceRabbitMqBus();
            _request = new LicensePlateRequestBuilder().ForIvid();
            _buildSourceChain = new CreateSourceChain(_request.Package);
            _buildSourceChain.Build();
            _initialize = new Initialize(new LaceResponse(), _request, _monitoring, _buildSourceChain);
        }


        public override void Observe()
        {
            _initialize.Execute();
            _laceResponses = _initialize.LaceResponses;
        }

        [Observation]
        public void lace_response_to_be_returned_should_be_one()
        {
            _laceResponses.Count.ShouldEqual(1);
        }

        [Observation]
        public void lace_ivid_response_should_be_handled()
        {
            _laceResponses[0].Response.IvidResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_ivid_response_shuould_not_be_null()
        {
            _laceResponses[0].Response.IvidResponse.ShouldNotBeNull();
        }
    }
}
