﻿using System;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_ivid_title_holder_data_provider : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringMessages _monitoring;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private IvidTitleHolderDataProvider _consumer;


        public when_consuming_ivid_title_holder_data_provider()
        {
            _monitoring = BusBuilder.ForMonitoringMessages(Guid.NewGuid());
             _request = new LicensePlateNumberIvidTitleHolderOnlyRequest();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
        }

        public override void Observe()
        {
            _consumer = new IvidTitleHolderDataProvider(_request, null, null);
            _consumer.CallSource(_response, _monitoring);
        }


        [Observation]
        public void ivid_title_holder_consumer_must_be_handled()
        {
            _response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void ivid_title_holder_response_from_consumer_must_not_be_null()
        {
            _response.IvidTitleHolderResponse.ShouldNotBeNull();
        }

        [Observation]
        public void ivid_title_holder_consumer_next_source_must_be_null()
        {
            _consumer.Next.ShouldBeNull();
        }

        [Observation]
        public void ivid_title_holder_consumer_fallback_source_must_be_null()
        {
            _consumer.FallBack.ShouldBeNull();
        }
    }
}
