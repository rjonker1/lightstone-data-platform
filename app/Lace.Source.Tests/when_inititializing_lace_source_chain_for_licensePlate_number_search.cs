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


        private MockLaceInitializer initialize;
        

        //private IList<LaceExternalServiceResponse> LaceResponses { get; set; }
        private readonly ILaceRequest _request;
        private Dictionary<Type, Func<ILaceRequest, ILaceResponse>> _handlers;

        public when_inititializing_lace_source_chain_for_licensePlate_number_search()
        {

            _request = new LicensePlateNumberSliverAllServicesRequest();

            
            //loader = new MockLaceLoader();
        }

        public override void Observe()
        {
            initialize = new MockLaceInitializer(_request);
        }

        [Observation]
        public void services_for_sliver_to_be_handled_loaded_correclty_test()
        {

			initialize.LaceResponses.Count.ShouldEqual(1);

			initialize.LaceResponses[0].Response.ShouldNotBeNull();

			initialize.LaceResponses[0].Response.IvidResponse.ShouldNotBeNull();

			initialize.LaceResponses[0].Response.IvidResponseHandled.Handled.ShouldBeTrue();

            initialize.LaceResponses[0].Response.IvidTitleHolderResponse.ShouldNotBeNull();

            initialize.LaceResponses[0].Response.IvidTitleHolderResponse.ShouldNotBeNull();

            //initialize.LaceResponses[0].Response.RgtVinResponse.ShouldNotBeNull();
        }
    }

}
