using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Xunit.Extensions;

namespace Lace.Unit.Tests.SourceRequests
{
    public class when_configuring_ivid_title_holder_request_message : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly IAmDataProvider _dataProvider;
        private TitleholderQueryRequest _configureRequestMessage;


        public when_configuring_ivid_title_holder_request_message()
        {
            _request = new LicensePlateRequestBuilder().ForIvidTitleHolder();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
            _dataProvider =
                _request.GetFromRequest<IPointToLaceRequest>().Package.DataProviders.Single(w => w.Name == DataProviderName.IvidTitleHolder);
        }

        public override void Observe()
        {
           _configureRequestMessage =
                HandleRequest.GetTitleholderQueryRequest(_response,_dataProvider.GetRequest<IAmIvidTitleholderRequest>());
        }

        [Observation]
        public void ivid_title_holder_request_message_mapped_vin_should_be_valid()
        {
            _configureRequestMessage.vin.ShouldEqual("SB1KV58E40F039277");
        }

        [Observation]
        public void ivid_title_holder_request_message_mapped_requestor_details_should_be_valid()
        {
            _configureRequestMessage.requesterDetails.ShouldNotBeNull();

            _configureRequestMessage.requesterDetails.requesterEmail.ShouldEqual(
                "murrayw@lightstone.co.za");
            _configureRequestMessage.requesterDetails.requesterPhone.ShouldBeEmpty();
            _configureRequestMessage.requesterDetails.requesterName.ShouldEqual("Murray Woolfson");
        }
    }
}
