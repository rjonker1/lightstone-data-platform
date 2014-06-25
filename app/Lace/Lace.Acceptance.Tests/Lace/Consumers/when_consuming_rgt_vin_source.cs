using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Source.RgtVin;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_rgt_vin_source : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private readonly ILaceResponse _response;
        private RgtVinConsumer _consumer;


        public when_consuming_rgt_vin_source()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _request = new LicensePlateNumberRgtVinOnlyRequest();
            _response = new LaceResponse();
        }

        public override void Observe()
        {
            _consumer = new RgtVinConsumer(_request, null, null);
            _consumer.CallSource(_response, _laceEvent);
        }


        [Observation]
        public void ivid_consumer_must_be_handled()
        {
            _response.IvidResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void ivid_response_from_consumer_must_not_be_null()
        {
            _response.IvidResponse.ShouldNotBeNull();
        }

        [Observation]
        public void ivid_consumer_next_source_must_be_null()
        {
            _consumer.Next.ShouldBeNull();
        }

        [Observation]
        public void ivid_consumer_fallback_source_must_be_null()
        {
            _consumer.FallBack.ShouldBeNull();
        }
    }
}
