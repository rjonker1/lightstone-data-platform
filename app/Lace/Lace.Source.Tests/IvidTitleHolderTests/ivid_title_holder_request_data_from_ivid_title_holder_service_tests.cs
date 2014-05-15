using System.Net.NetworkInformation;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Source.IvidTitleHolder.ServiceCalls;
using Lace.Source.Tests.Data.IvidTitleHolder;
using Lace.Tests.Data.Fakes;
using Xunit.Extensions;

namespace Lace.Source.Tests.IvidTitleHolderTests
{
    public class ivid_title_holder_request_data_from_ivid_title_holder_service_tests : Specification
    {
        private readonly IRequestDataFromService _requestDataFromService;
        private readonly ILaceRequest _ividTitleHolderRequest;
        private ILaceResponse _laceResponse;
        private ILaceEvent _laceEvent;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public ivid_title_holder_request_data_from_ivid_title_holder_service_tests()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _requestDataFromService = new RequestDatafromIvidTitleHolderService();
            _ividTitleHolderRequest =
                MockIvidTitleHolderLicensePlateNumberRequestData.GetLicensePlateNumberRequestForIvidTitleHolder();
            _laceResponse = new LaceResponse();
            _externalWebServiceCall = new MockCallingIvidTitleHolderExternalWebService();
        }


        public override void Observe()
        {
            _requestDataFromService.FetchDataFromService(_laceResponse, _externalWebServiceCall, _laceEvent);
        }

        [Observation]
        public void ivid_title_holder_request_data_from_service_response_must_not_be_null_test()
        {
            _laceResponse.IvidTitleHolderResponse.ShouldNotBeNull();
        }

        [Observation]
        public void ivid_title_holder_request_data_from_service_must_be_handled_test()
        {
            _laceResponse.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();
        }
    }
}
