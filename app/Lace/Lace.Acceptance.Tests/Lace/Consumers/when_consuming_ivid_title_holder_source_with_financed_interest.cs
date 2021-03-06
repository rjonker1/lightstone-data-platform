﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_ivid_title_holder_source_with_financed_interest : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private IvidTitleHolderDataProvider _consumer;
        
        public when_consuming_ivid_title_holder_source_with_financed_interest()
        {
            _command = MonitoringBusBuilder.ForIvidTitleHolderCommands(Guid.NewGuid());
            _request = new[] {new LicensePlateNumberIvidTitleHolderWithAbsaFinancedInterestRequest()};
            _response = new LaceResponseBuilder().WithIvidResponseAndFinancedInterestVin();
        }

        public override void Observe()
        {
            _consumer = new IvidTitleHolderDataProvider(_request, null, null,_command);
            _consumer.CallSource(_response);
        }


        [Observation]
        public void ivid_title_holder_consumer_with_financed_interest_must_be_handled()
        {
            _response.OfType<IProvideDataFromIvidTitleHolder>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void ivid_title_holder_response_from_consumer_with_financed_interest_must_not_be_null()
        {
            _response.OfType<IProvideDataFromIvidTitleHolder>().First().ShouldNotBeNull();
        }

        [Observation]
        public void ivid_title_holder_consumer_with_financed_interest_next_source_must_be_null()
        {
            _consumer.Next.ShouldBeNull();
        }

        [Observation]
        public void ivid_title_holder_consumer_with_financed_interest_fallback_source_must_be_null()
        {
            _consumer.FallBack.ShouldBeNull();
        }

        [Observation(Skip = "ABSA Financed Interests not avail")]
        public void ivid_title_holder_consumer_with_financed_interest_should_be_available()
        {
            _response.OfType<IProvideDataFromIvidTitleHolder>().First().FinancialInterestAvailable.ShouldBeTrue();
        }
    }
}
