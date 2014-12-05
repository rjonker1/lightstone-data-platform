﻿using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Bus;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_ivid_title_holder : Specification
    {

        private readonly ILaceRequest _request;
        private readonly ISendMonitoringMessages _laceEvent;
        private readonly IBootstrap _initialize;
        private IList<LaceExternalSourceResponse> _laceResponses;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_initializing_lace_handlers_for_ivid_title_holder()
        {
            //var bus = new FakeBus();
            //var publisher = new Workflow.RabbitMQ.Publisher(bus);
            

            _request = new LicensePlateRequestBuilder().ForIvidTitleHolder();
           // _laceEvent = new PublishLaceEventMessages(publisher, _request.RequestAggregation.AggregateId);


            _buildSourceChain = new CreateSourceChain(_request.Package);
            _buildSourceChain.Build();


            _initialize = new Initialize(new LaceResponse(),_request, _laceEvent, _buildSourceChain);
        }

        public override void Observe()
        {
            _initialize.Execute();
            _laceResponses = _initialize.LaceResponses;
        }

        [Observation]
        public void lace_functional_test_ivid_title_holder_response_should_be_handled_test()
        {
            _laceResponses[0].Response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_functional_test_ivid_title_holder_response_shuould_not_be_null_test()
        {
            _laceResponses[0].Response.IvidTitleHolderResponse.ShouldNotBeNull();
        }

    }
}
