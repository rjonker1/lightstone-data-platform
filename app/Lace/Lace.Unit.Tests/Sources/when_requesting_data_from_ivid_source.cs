using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Source;
using Lace.Source.Ivid.ServiceCalls;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Fakes.Lace.SourceCalls;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources
{
    public class ivid_request_data_from_ivid_service_tests : Specification
    {
        private readonly IRequestDataFromSource _requestDataFromService;
        private readonly ILaceRequest _ividRequest;
        private ILaceResponse _laceResponse;
        private readonly ILaceEvent _laceEvent;
        private readonly ICallTheSource _externalWebServiceCall;

        public ivid_request_data_from_ivid_service_tests()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _requestDataFromService = new RequestDataFromIvidSource();
            _ividRequest = new LicensePlateRequestBuilder().ForIvid();
            _laceResponse = new LaceResponse();
            _externalWebServiceCall = new FakeCallingIvidExternalWebService();
           
        }
        
        public override void Observe()
        {
            _requestDataFromService.FetchDataFromService(_laceResponse, _externalWebServiceCall, _laceEvent);
        }

        [Observation]
        public void lace_ivid_request_data_from_service_response_must_not_be_null()
        {
            _laceResponse.IvidResponse.ShouldNotBeNull();
        }

        [Observation]
        public void lace_ivid_request_data_from_service_must_be_handled()
        {
            _laceResponse.IvidResponseHandled.Handled.ShouldBeTrue();
        }


    }
}
