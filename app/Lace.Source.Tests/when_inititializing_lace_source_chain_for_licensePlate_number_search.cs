using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Response;
using Lace.Source.Tests.Data;
using Lace.Source.Tests.Data.Initialization;
using Xunit;
using Xunit.Extensions;

namespace Lace.Source.Tests
{
    public class when_inititializing_lace_source_chain_for_licensePlate_number_search : Specification
    {
        private MockLaceInitializer _initialize;

        private readonly ILaceRequest _request;
        private Dictionary<Type, Func<ILaceRequest, ILaceResponse>> _handlers;

        public when_inititializing_lace_source_chain_for_licensePlate_number_search()
        {
            _request = new LicensePlateNumberSliverAllServicesRequest();
        }

        public override void Observe()
        {
            _initialize = new MockLaceInitializer(_request);
        }

        [Observation]
        public void services_for_sliver_to_be_handled_loaded_correclty_test()
        {

            _initialize.LaceResponses.Count.ShouldEqual(1);
            _initialize.LaceResponses[0].Response.ShouldNotBeNull();

            _initialize.LaceResponses[0].Response.IvidResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.IvidResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.IvidTitleHolderResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.RgtVinResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.RgtVinResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.AudatexResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.AudatexResponseHandled.Handled.ShouldBeTrue();

        }
    }
}
