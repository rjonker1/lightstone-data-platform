﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_ivid_title_holder_data_provider : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;
        private readonly ICollection<IPointToLaceProvider> _response;
        private IvidTitleHolderDataProvider _consumer;


        public when_consuming_ivid_title_holder_data_provider()
        {
            _monitoring = MonitoringBusBuilder.ForIvidTitleHolderCommands(Guid.NewGuid());
            _request = new[] {new LicensePlateNumberIvidTitleHolderOnlyRequest()};
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
        }

        public override void Observe()
        {
            _consumer = new IvidTitleHolderDataProvider(_request, null, null, _monitoring);
            _consumer.CallSource(_response);
        }


        [Observation]
        public void ivid_title_holder_consumer_must_be_handled()
        {
            _response.OfType<IProvideDataFromIvidTitleHolder>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void ivid_title_holder_response_from_consumer_must_not_be_null()
        {
            _response.OfType<IProvideDataFromIvidTitleHolder>().First().ShouldNotBeNull();
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
