using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Source;
using Lace.Source.Lightstone.SourceCalls;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_lightstone_source : Specification
    {
        private readonly IRequestDataFromSource _requestDataFromSource;
        private readonly ILaceRequest _request;
        private ILaceResponse _response;
        private readonly ILaceEvent _laceEvent;
        private readonly ICallTheSource _callTheSource;

        public when_requesting_data_from_lightstone_source()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);

            _requestDataFromSource = new RequestDataFromLightstoneSource();
            _request = new LicensePlateRequestBuilder().ForLightstone();
            _response = new LaceResponse();
            _callTheSource = new CallLightstoneExternalSource(_request, new FakeRepositoryFactory());
            _laceEvent = new PublishLaceEventMessages(publisher, _request.RequestAggregation.AggregateId);
        }

        public override void Observe()
        {
            _requestDataFromSource.FetchDataFromSource(_response, _callTheSource, _laceEvent);
        }

        [Observation]
        public void lace_lightstone_request_data_from_service_response_must_not_be_null()
        {
            _response.LightstoneResponse.ShouldNotBeNull();
        }

        [Observation]
        public void lace_lightstone_request_data_from_service_must_be_handled()
        {
            _response.LightstoneResponseHandled.Handled.ShouldBeTrue();
        }
    }
}
