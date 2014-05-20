﻿using System.Collections.Generic;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Request.Load;
using Lace.Request.Load.Loaders;
using Lace.Response.ExternalServices;
using Lace.Source.Tests.Data;
using Lace.Tests.Data.Fakes;
using Xunit.Extensions;

namespace Lace.Source.Tests
{
    public class initialize_lace_handlers_for_ivid_request_functional_test : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private readonly Initialize _initialize;
        private IList<LaceExternalServiceResponse> _laceResponses;
        private ILoadRequestSources _loadRequestSources;

        public initialize_lace_handlers_for_ivid_request_functional_test()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _request = new LicensePlateNumberIvidOnlyRequest();
            _loadRequestSources = new LaceLicensePlateNumberLoader();
            _initialize = new Initialize(_request, _loadRequestSources, _laceEvent);
        }


        public override void Observe()
        {
            _laceResponses = _initialize.LaceResponses;
        }

        [Observation]
        public void lace_functional_test_response_to_be_returned_should_be_one_test()
        {
            _laceResponses.Count.ShouldEqual(1);
        }


        [Observation]
        public void lace_functional_test_ivid_response_should_be_handled_test()
        {
            _laceResponses[0].Response.IvidResponseHandled.Handled.ShouldEqual(true);
        }

        [Observation]
        public void lace_functional_test_ivid_response_shuould_not_be_null_test()
        {
            _laceResponses[0].Response.IvidResponse.ShouldNotBeNull();
        }
    }
}