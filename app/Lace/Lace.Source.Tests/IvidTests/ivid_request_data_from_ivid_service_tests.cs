using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Source.Ivid.ServiceCalls;
using Lace.Source.Tests.Data.Ivid;
using Lace.Tests.Data.Fakes;
using Xunit.Extensions;

namespace Lace.Source.Tests.IvidTests
{
    public class ivid_request_data_from_ivid_service_tests : Specification
    {
        private readonly IRequestDataFromService _requestDataFromService;
        private readonly ILaceRequest _ividRequest;
        private ILaceResponse _laceResponse;
        private readonly ILaceEvent _laceEvent;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public ivid_request_data_from_ivid_service_tests()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _requestDataFromService = new RequestDataFromIvidService();
            _ividRequest = MockIvidLicensePlateNumberRequestData.GetLicensePlateNumberRequestForIvid();
            _laceResponse = new LaceResponse();
            _externalWebServiceCall = new MockCallingIvidExternalWebService();
           
        }
        
        public override void Observe()
        {
            _requestDataFromService.FetchDataFromService(_laceResponse, _externalWebServiceCall, _laceEvent);
        }

        [Observation]
        public void ivid_request_data_from_service_response_must_not_be_null_test()
        {
            _laceResponse.IvidResponse.ShouldNotBeNull();
        }

        [Observation]
        public void ivid_request_data_from_service_must_be_handled_test()
        {
            _laceResponse.IvidResponseHandled.Handled.ShouldBeTrue();
        }


    }
}
