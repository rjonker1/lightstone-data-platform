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
        private RgtVinSourceExecution _consumer;


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
            _consumer = new RgtVinSourceExecution(_request, null, null);
            _consumer.CallSource(_response, _laceEvent);
        }


        [Observation]
        public void rgt_vin_consumer_must_be_handled()
        {
            _response.RgtVinResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void rgt_vin_response_from_consumer_must_not_be_null()
        {
            _response.RgtVinResponse.ShouldNotBeNull();
        }

        [Observation]
        public void rgt_vin_consumer_next_source_must_be_null()
        {
            _consumer.Next.ShouldBeNull();
        }

        [Observation]
        public void rgt_vin_consumer_fallback_source_must_be_null()
        {
            _consumer.FallBack.ShouldBeNull();
        }
    }
}
