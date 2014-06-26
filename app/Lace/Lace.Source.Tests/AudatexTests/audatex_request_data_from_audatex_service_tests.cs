using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.ServiceCalls;
using Lace.Source.Tests.Data.Audatex;
using Lace.Tests.Data.Fakes;
using Xunit.Extensions;

namespace Lace.Source.Tests.AudatexTests
{
    public class audatex_request_data_from_audatex_service_tests : Specification
    {
        private readonly IRequestDataFromSource _requestDataFromService;
        private readonly ILaceRequest _audatexRequest;
        private ILaceResponse _laceResponse;
        private ILaceEvent _laceEvent;
        private readonly ICallTheSource _externalWebServiceCall;


        public audatex_request_data_from_audatex_service_tests()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _requestDataFromService = new RequestDataFromAudatexSource();
            _audatexRequest = MockAudatexLicensePlateNumberRequestData.GetLicensePlateNumberRequestForAudatex();
            _laceResponse = new LaceResponse();
            _externalWebServiceCall = new MockCallingAudatexExternalWebService(_audatexRequest);
        }

        public override void Observe()
        {
            _requestDataFromService.FetchDataFromSource(_laceResponse, _externalWebServiceCall, _laceEvent);
        }

        [Observation]
        public void audatex_request_data_from_service_web_response_must_not_be_null_test()
        {
            _laceResponse.AudatexResponse.ShouldNotBeNull();
        }

        [Observation]
        public void audatex_request_data_from_service_must_be_handled_test()
        {
            _laceResponse.AudatexResponseHandled.Handled.ShouldBeTrue();
        }
    }
}
