﻿using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using NServiceBus;
using ServiceStack.Common.Extensions;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Requests
{
    public class when_sending_request_to_lace_entry_point : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private ICollection<IPointToLaceProvider> _response;
        private readonly IEntryPoint _entryPoint;
        private readonly IBus _bus;

        public when_sending_request_to_lace_entry_point()
        {
            _bus = BusFactory.WorkflowBus();
            _request = new LicensePlateRequestBuilder().ForAllSources();
            _entryPoint = new EntryPointService(_bus);
        }

        public override void Observe()
        {
            _response = _entryPoint.GetResponsesFromLace(_request);
        }

        [Observation]
        public void lace_request_to_be_loaded_and_responses_to_be_returned_for_all_sources()
        {
            _response.ShouldNotBeNull();
            _response.Count.ShouldEqual(6);
            
            _response.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();

            _response.OfType<IProvideDataFromIvidTitleHolder>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromIvidTitleHolder>().First().Handled.ShouldBeTrue();

            _response.OfType<IProvideDataFromRgtVin>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromRgtVin>().First().Handled.ShouldBeTrue();

            _response.OfType<IProvideDataFromRgt>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromRgt>().First().Handled.ShouldBeTrue();

            _response.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();

            _response.OfType<IProvideDataFromAudatex>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromAudatex>().First().Handled.ShouldBeTrue();
        }
    }
}
