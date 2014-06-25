using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Source.IvidTitleHolder;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_ivid_title_holder_source : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private readonly ILaceResponse _response;
        private IvidTitleHolderConsumer _consumer;


        public when_consuming_ivid_title_holder_source()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _request = new LicensePlateNumberIvidTitleHolderOnlyRequest();
            _response = new LaceResponse();
        }

        public override void Observe()
        {
            _consumer = new IvidTitleHolderConsumer(_request, null, null);
            _consumer.CallSource(_response, _laceEvent);
        }


        [Observation]
        public void ivid_title_holder_consumer_must_be_handled()
        {
            _response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void ivid_title_holder_response_from_consumer_must_not_be_null()
        {
            _response.IvidTitleHolderResponse.ShouldNotBeNull();
        }

        [Observation]
        public void ivid_title_holder_consumer_next_source_must_be_null()
        {
            _consumer.Next.ShouldBeNull();
        }

        [Observation]
        public void ivid_title_holder_consumer_fallback_source_must_be_null()
        {
            _consumer.FallBack.ShouldBeNull();
        }
    }
}
