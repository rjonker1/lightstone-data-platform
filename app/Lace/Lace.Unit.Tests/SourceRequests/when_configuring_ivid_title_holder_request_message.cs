﻿using Lace.Models.Ivid;
using Lace.Request;
using Lace.Response;
using Lace.Source.Ivid.Transform;
using Lace.Source.IvidTitleHolder.ServiceConfig;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Xunit.Extensions;

namespace Lace.Unit.Tests.SourceRequests
{
    internal class when_configuring_ivid_title_holder_request_message : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ILaceResponse _response;
        private ConfigureIvidTitleHolderRequestMessage _configureRequestMessage;


        public when_configuring_ivid_title_holder_request_message()
        {
            _request = new LicensePlateRequestBuilder().ForIvidTitleHolder();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
        }

        public override void Observe()
        {
            _configureRequestMessage = new ConfigureIvidTitleHolderRequestMessage(_request, _response);
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