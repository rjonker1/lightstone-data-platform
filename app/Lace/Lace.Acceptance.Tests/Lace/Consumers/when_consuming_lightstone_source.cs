using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_lightstone_source : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringMessages _laceEvent;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private LightstoneDataProvider _consumer;

        public when_consuming_lightstone_source()
        {
            //var bus = new FakeBus();
            //var publisher = new Workflow.RabbitMQ.Publisher(bus);

            _request = new LicensePlateNumberLightstoneOnlyRequest();
           // _laceEvent = new PublishLaceEventMessages(publisher, _request.RequestAggregation.AggregateId);
            _response = new LaceResponse();
        }

        public override void Observe()
        {
            _consumer = new LightstoneDataProvider(_request, null, null);
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
