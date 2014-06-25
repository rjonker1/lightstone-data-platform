using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Source.Ivid;
using Lace.Source.Tests.Data;
using Lace.Tests.Data.Fakes;
using Xunit.Extensions;

namespace Lace.Source.Tests.IvidTests
{
    public class ivid_web_service_being_consumed_tests : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private readonly ILaceResponse _response;

        public ivid_web_service_being_consumed_tests()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _request = new LicensePlateNumberIvidOnlyRequest();
            _response = new LaceResponse();
        }

        public override void Observe()
        {
            var consumer = new IvidConsumer(_request);
            consumer.CallSource(_response, _laceEvent);
        }

        [Observation]
        public void ivid_web_service_must_be_handled()
        {
            _response.IvidResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void ivid_web_service_response_must_not_be_null()
        {
            _response.IvidResponse.ShouldNotBeNull();
        }
    }
}
