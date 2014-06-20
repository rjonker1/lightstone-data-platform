﻿using System.Collections.Generic;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Request.Load;
using Lace.Request.Load.Loaders;
using Lace.Response.ExternalServices;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Bus;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_ivid_request : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private readonly Initialize _initialize;
        private IList<LaceExternalServiceResponse> _laceResponses;
        private ILoadRequestSources _loadRequestSources;

        public when_initializing_lace_handlers_for_ivid_request()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _request = new LicensePlateRequestBuilder().ForIvid();
            _loadRequestSources = new LicensePlateNumberSourceLoader();
            _initialize = new Initialize(_request, _loadRequestSources, _laceEvent);
        }


        public override void Observe()
        {
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
            _laceResponses[0].Response.IvidResponseHandled.Handled.ShouldEqual(true);
        }

        [Observation]
        public void lace_ivid_response_shuould_not_be_null()
        {
            _laceResponses[0].Response.IvidResponse.ShouldNotBeNull();
        }
    }
}
