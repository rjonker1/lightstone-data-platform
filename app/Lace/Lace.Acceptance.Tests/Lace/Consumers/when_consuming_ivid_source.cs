using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_ivid_source : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringMessages _laceEvent;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private IvidDataProvider _consumer;


        public when_consuming_ivid_source()
        {
            //var bus = new FakeBus();
            //var publisher = new Workflow.RabbitMQ.Publisher(bus);

            _request = new LicensePlateNumberIvidOnlyRequest();

            //_laceEvent = new PublishLaceEventMessages(publisher, _request.RequestAggregation.AggregateId);

            _response = new LaceResponse();
        }

        public override void Observe()
        {
            _consumer = new IvidDataProvider(_request, null, null);
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
