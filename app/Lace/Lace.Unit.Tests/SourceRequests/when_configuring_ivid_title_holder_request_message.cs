using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Dto;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using ServiceStack.Common.Extensions;
using Xunit.Extensions;

namespace Lace.Unit.Tests.SourceRequests
{
    internal class when_configuring_ivid_title_holder_request_message : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private IvidTitleHolderRequestMessage _configureRequestMessage;


        public when_configuring_ivid_title_holder_request_message()
        {
            _request = new LicensePlateRequestBuilder().ForIvidTitleHolder();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
        }

        public override void Observe()
        {
            _configureRequestMessage = new IvidTitleHolderRequestMessage(_request.GetFromRequest<IPointToVehicleRequest>().User, _response);
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

            _configureRequestMessage.TitleholderQueryRequest.requesterDetails.requesterEmail.ShouldEqual(
                "pennyl@lightstone.co.za");
            _configureRequestMessage.TitleholderQueryRequest.requesterDetails.requesterPhone.ShouldBeEmpty();
            _configureRequestMessage.TitleholderQueryRequest.requesterDetails.requesterName.ShouldEqual("Penny");
        }
    }
}
