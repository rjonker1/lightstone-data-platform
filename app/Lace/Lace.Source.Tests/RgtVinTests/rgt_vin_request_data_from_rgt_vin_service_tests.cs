using System.Net.NetworkInformation;
using Lace.Events;
using Lace.Events.Messages;
using Lace.Request;
using Lace.Response;
using Lace.Source.RgtVin.ServiceCalls;
using Lace.Source.Tests.Data.RgtVin;
using Lace.Tests.Data.Fakes;
using Xunit.Extensions;

namespace Lace.Source.Tests.RgtVinTests
{
    public class rgt_vin_request_data_from_rgt_vin_service_tests : Specification
    {
        private readonly IRequestDataFromService _requestDataFromService;
        private readonly ILaceRequest _rgtVinRequest;
        private ILaceResponse _laceResponse;
        private ILaceEvent _laceEvent;
        private readonly ICallTheExternalWebService _externalWebServiceCall;

        public rgt_vin_request_data_from_rgt_vin_service_tests()
        {
            _laceEvent = new PublishEvent(new FakeBus());
            _requestDataFromService = new RequestDataFromRgtVinService();
            _rgtVinRequest = MockRgtVinLicensePlateNumberRequestData.GetLicensePlateNumberReqeustForRgtVinRequest();
            _laceResponse = new LaceResponse();
            _externalWebServiceCall = new MockCallingRgtVinExternalWebService();
        }

        public override void Observe()
        {
            _requestDataFromService.FetchDataFromService(_laceResponse, _externalWebServiceCall, _laceEvent);
        }

        [Observation]
        public void rgt_vin_request_data_from_service_response_must_not_be_null_test()
        {
            _laceResponse.RgtVinResponse.ShouldNotBeNull();
        }

        [Observation]
        public void rgt_vin_request_data_from_service_must_be_handled_test()
        {
            _laceResponse.RgtVinResponseHandled.Handled.ShouldBeTrue();
        }
    }
}
