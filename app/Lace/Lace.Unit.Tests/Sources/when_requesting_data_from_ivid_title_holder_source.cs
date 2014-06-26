using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Source;
using Lace.Source.Ivid.ServiceCalls;
using Lace.Source.IvidTitleHolder.ServiceCalls;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class when_requesting_data_from_ivid_title_holder_source : Specification
    {
        private readonly IRequestDataFromSource _requestDataFromService;
        private readonly ILaceRequest _ividTitleHolderRequest;
        private ILaceResponse _laceResponse;
        private readonly ILaceEvent _laceEvent;
        private readonly ICallTheSource _externalWebServiceCall;

        public when_requesting_data_from_ivid_title_holder_source()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);

            _laceEvent = new PublishLaceEventMessages(publisher);
            _requestDataFromService = new RequestDatafromIvidTitleHolderSource();
            _ividTitleHolderRequest = new LicensePlateRequestBuilder().ForIvidTitleHolder();
            _laceResponse = new LaceResponse();
            _externalWebServiceCall = new FakeCallingIvidTitleHolderExternalWebService();

        }

        public override void Observe()
        {
            _requestDataFromService.FetchDataFromSource(_laceResponse, _externalWebServiceCall, _laceEvent);
        }

        [Observation]
        public void ivid_title_holder_request_data_from_service_response_must_not_be_nul()
        {
            _laceResponse.IvidTitleHolderResponse.ShouldNotBeNull();
        }

        [Observation]
        public void ivid_title_holder_request_data_from_service_must_be_handled()
        {
            _laceResponse.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();
        }


    }
}
