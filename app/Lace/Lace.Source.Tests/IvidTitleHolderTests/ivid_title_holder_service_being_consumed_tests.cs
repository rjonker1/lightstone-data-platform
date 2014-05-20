﻿using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Source.IvidTitleHolder;
using Lace.Source.Tests.Data;
using Lace.Tests.Data.Fakes;
using Xunit.Extensions;

namespace Lace.Source.Tests.IvidTitleHolderTests
{
    public class ivid_title_holder_service_being_consumed_tests : Specification
    {

        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private ILaceResponse _response;

        public ivid_title_holder_service_being_consumed_tests()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _request = new LicensePlateNumberIvidTitleHolderOnlyRequest();
            _response = new LaceResponse();
        }

        public override void Observe()
        {
            var consumer = new IvidTitleHolderConsumer(_request);
            consumer.CallIvidTitleHolderService(_response, _laceEvent);
        }

        [Observation]
        public void ivid_title_holder_web_service_must_be_handled_test()
        {
            _response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void ivid_title_holder_web_service_response_must_not_be_null_test()
        {
            _response.IvidTitleHolderResponse.ShouldNotBeNull();
        }
    }
}