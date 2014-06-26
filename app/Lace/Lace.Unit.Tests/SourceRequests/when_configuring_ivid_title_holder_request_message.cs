using Lace.Request;
using Lace.Source.IvidTitleHolder.ServiceConfig;
using Lace.Test.Helper.Builders.Requests;
using Xunit.Extensions;

namespace Lace.Unit.Tests.SourceRequests
{
    class when_configuring_ivid_title_holder_request_message : Specification
    {
        private readonly ILaceRequest _request;
        private ConfigureIvidTitleHolderRequestMessage _configureRequestMessage;


        public when_configuring_ivid_title_holder_request_message()
        {
            _request = new LicensePlateRequestBuilder().ForIvidTitleHolder();
        } 


        public override void Observe()
        {
            _configureRequestMessage = new ConfigureIvidTitleHolderRequestMessage(_request);
        }

        [Observation]
        public void ivid_title_holder_request_message_mapped_vin_should_be_valid()
        {
            _configureRequestMessage.TitleholderQueryRequest.vin.ShouldEqual("AHT31UNK408007735");
        }

        [Observation]
        public void ivid_title_holder_request_message_mapped_requestor_details_should_be_valid()
        {
            _configureRequestMessage.TitleholderQueryRequest.requesterDetails.ShouldNotBeNull();

            _configureRequestMessage.TitleholderQueryRequest.requesterDetails.requesterEmail.ShouldEqual("pennyl@lightstone.co.za");
            _configureRequestMessage.TitleholderQueryRequest.requesterDetails.requesterPhone.ShouldBeEmpty();
            _configureRequestMessage.TitleholderQueryRequest.requesterDetails.requesterName.ShouldEqual("Penny");
        }
    }
}
