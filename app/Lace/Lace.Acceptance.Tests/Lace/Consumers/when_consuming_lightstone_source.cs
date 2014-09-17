using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Models.Responses;
using Lace.Request;
using Lace.Response;
using Lace.Source.Lightstone;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_lightstone_source : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private readonly ILaceResponse _response;
        private LightstoneSourceExecution _consumer;

        public when_consuming_lightstone_source()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);

            _request = new LicensePlateNumberLightstoneOnlyRequest();
            _laceEvent = new PublishLaceEventMessages(publisher, _request.RequestAggregation.AggregateId);
            _response = new LaceResponse();
        }

        public override void Observe()
        {
            _consumer = new LightstoneSourceExecution(_request, null, null);
            _consumer.CallSource(_response, _laceEvent);
        }

        [Observation]
        public void lightstone_consumer_must_be_handled()
        {
            _response.LightstoneResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lightstone_response_from_consumer_must_not_be_null()
        {
            _response.LightstoneResponse.ShouldNotBeNull();
        }
    }
}
