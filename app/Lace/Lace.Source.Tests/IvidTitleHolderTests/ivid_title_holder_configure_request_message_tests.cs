using Lace.Request;
using Lace.Source.IvidTitleHolder.ServiceConfig;
using Lace.Source.Tests.Data;
using Xunit.Extensions;

namespace Lace.Source.Tests.IvidTitleHolderTests
{
    public class ivid_title_holder_configure_request_message_tests : Specification
    {

        private readonly ILaceRequest _request;
        private ConfigureIvidTitleHolderRequestMessage _configureRequestMessage;


        public ivid_title_holder_configure_request_message_tests()
        {
            _request = new LicensePlateNumberIvidTitleHolderOnlyRequest();
            
        }

        public override void Observe()
        {
            _configureRequestMessage = new ConfigureIvidTitleHolderRequestMessage(_request);
        }

        [Observation]
        public void ivid_title_holder_request_message_mapped_vin_should_be_valid_test()
        {
            _configureRequestMessage.TitleholderQueryRequest.vin.ShouldEqual("AHT31UNK408007735");
        }

        [Observation]
        public void ivid_title_holder_request_message_mapped_requestor_details_should_be_valid_test()
        {
            _configureRequestMessage.TitleholderQueryRequest.requesterDetails.ShouldNotBeNull();

            _configureRequestMessage.TitleholderQueryRequest.requesterDetails.requesterEmail.ShouldEqual("pennyl@lightstone.co.za");
            _configureRequestMessage.TitleholderQueryRequest.requesterDetails.requesterPhone.ShouldBeEmpty();
            _configureRequestMessage.TitleholderQueryRequest.requesterDetails.requesterName.ShouldEqual("Penny");
        }
    }
}
