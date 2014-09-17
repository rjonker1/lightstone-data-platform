using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Models.Responses;
using Lace.Request;
using Lace.Source.Audatex;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_audatex_source : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private readonly ILaceResponse _response;
        private AudatexSourceExecution _consumer;


        public when_consuming_audatex_source()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);

            _request = new LicensePlateNumberAudatexOnlyRequest();

            _laceEvent = new PublishLaceEventMessages(publisher, _request.RequestAggregation.AggregateId);
            _response = new LaceResponseBuilder().WithIvidResponseHandledAndVin12();
        }

        public override void Observe()
        {
            _consumer = new AudatexSourceExecution(_request, null, null);
            _consumer.CallSource(_response, _laceEvent);
        }


        [Observation]
        public void audatex_consumer_must_be_handled()
        {
            _response.AudatexResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void audatex_response_from_consumer_must_not_be_null()
        {
            _response.AudatexResponse.ShouldNotBeNull();
        }

        [Observation]
        public void audatex_consumer_next_source_must_be_null()
        {
            _consumer.Next.ShouldBeNull();
        }

        [Observation]
        public void audatex_consumer_fallback_source_must_be_null()
        {
            _consumer.FallBack.ShouldBeNull();
        }

        [Observation]
        public void audatex_consumer_accident_claims_should_not_be_zero()
        {
            _response.AudatexResponse.AccidentClaims.Count.ShouldNotEqual(0);
        }
    }
}
