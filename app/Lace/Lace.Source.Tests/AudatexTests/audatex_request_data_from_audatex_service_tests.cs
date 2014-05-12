using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.ServiceCalls;
using Lace.Source.Tests.Data.Audatex;
using Xunit.Extensions;

namespace Lace.Source.Tests.AudatexTests
{
    public class audatex_request_data_from_audatex_service_tests : Specification
    {
        private readonly IRequestDataFromService _requestDataFromService;
        private readonly ILaceRequest _audatexRequest;
        private ILaceResponse _laceResponse;
        private readonly ICallTheExternalWebService _externalWebServiceCall;


        public audatex_request_data_from_audatex_service_tests()
        {
            _requestDataFromService = new RequestDataFromAudatexService();
            _audatexRequest = MockAudatexLicensePlateNumberRequestData.GetLicensePlateNumberRequestForAudatex();
            _laceResponse = new LaceResponse();
            _externalWebServiceCall = new MockCallingAudatexExternalWebService(_audatexRequest);
        }

        public override void Observe()
        {
            _requestDataFromService.FetchDataFromService(_laceResponse, _externalWebServiceCall);
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
