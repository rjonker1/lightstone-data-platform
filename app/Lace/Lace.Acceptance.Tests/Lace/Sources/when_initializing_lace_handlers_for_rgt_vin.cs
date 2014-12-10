using System;
using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_rgt_vin : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringMessages _monitoring;
        private readonly IBootstrap _initialize;
        private IList<LaceExternalSourceResponse> _laceResponses;
        private readonly IBuildSourceChain _buildSourceChain;


        public when_initializing_lace_handlers_for_rgt_vin()
        {
            _monitoring = BusBuilder.ForMonitoringMessages(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForRgtVin();
            _buildSourceChain = new CreateSourceChain(_request.Package);
            _buildSourceChain.Build();
            _initialize = new Initialize(new LaceResponseBuilder().WithIvidResponseHandled(), _request, _monitoring,
                _buildSourceChain);
        }

        public override void Observe()
        {
            _initialize.Execute();
            _laceResponses = _initialize.LaceResponses;
        }

        [Observation]
        public void lace_functional_test_rgt_vin_response_should_be_handled()
        {
            _laceResponses[0].Response.RgtVinResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_functional_test_rgt_vin_response_shuould_not_be_null()
        {
            _laceResponses[0].Response.RgtVinResponse.ShouldNotBeNull();
        }
    }
}
