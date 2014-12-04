using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.RgtVin;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_rgt_vin_source : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringMessages _laceEvent;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private RgtVinDataProvider _consumer;


        public when_consuming_rgt_vin_source()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
           
            _request = new LicensePlateNumberRgtVinOnlyRequest();
           // _laceEvent = new PublishLaceEventMessages(publisher,_request.RequestAggregation.AggregateId);

            _response = new LaceResponseBuilder().WithIvidResponseHandled();
        }

        public override void Observe()
        {
            _consumer = new RgtVinDataProvider(_request, null, null);
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
