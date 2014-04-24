using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Operations;
using Lace.Request;
using Lace.Response;
using Lace.Source.Tests.Data.Initialization;
using Xunit;
using Xunit.Extensions;

namespace Lace.Source.Tests
{
    public class when_inititializing_lace_source_chain_for_licensePlate_number_search : Specification
    {


        private MockLaceInitializer initialize;
        private MockLaceLoader loader;

        private LaceOperation bootstrap;

        //private IList<LaceExternalServiceResponse> LaceResponses { get; set; }
        private readonly ILaceRequest _request;
        private Dictionary<Type, Func<ILaceRequest, ILaceResponse>> _handlers;

        public when_inititializing_lace_source_chain_for_licensePlate_number_search()
        {
            initialize = new MockLaceInitializer();
			loader = new MockLaceLoader();
        }
		
        public override void Observe()
        {
            bootstrap = new LaceOperation(loader)
            {
                LaceBootstrap = initialize
            };
        }

        [Observation]
        public void services_for_sliver_to_be_handled_must_be_true_test()
        {

            initialize.LoadTheExternalSourceHandlers(_request, _handlers);
            initialize.LaceResponses.ShouldNotBeNull();

            initialize.LaceResponses.Count.ShouldEqual(1);


            initialize.LaceResponses.First().Response.IvidResponseHandled.Handled.ShouldBeTrue();
            initialize.LaceResponses.First().Response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();
            initialize.LaceResponses.First().Response.RgtVinResponseHandled.Handled.ShouldBeTrue();
        }



        //private readonly ILaceRequest _request;
        //private readonly Initialize _initialize;
        //private List<LaceExternalServiceResponse> _laceResponses;

        //public when_inititializing_lace_source_chain_for_licensePlate_number_search()
        //{
        //    _request = BuildRequest();
        //    _initialize = new Initialize();
        //}

        //private static ILaceRequest BuildRequest()
        //{
        //    return new LicensePlateNumberSliverAllServicesRequest();
        //}

        //public override void Observe()
        //{
        //    try
        //    {
        //        _laceResponses = _initialize
        //            .Bootstrap(_request)
        //            .Load()
        //            .LaceResponses;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //[Observation]
        //public void services_for_sliver_to_be_handled_must_be_true()
        //{
        //    _laceResponses.First().Response.IvidResponseHandled.Handled.ShouldBeTrue();
        //    _laceResponses.First().Response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();
        //    _laceResponses.First().Response.RgtVinResponseHandled.Handled.ShouldBeTrue();
        //}

    }

}
