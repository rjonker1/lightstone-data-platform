using System.Collections.Generic;
using Lace.Request.Entry;
using Lace.Request.Load;
using Lace.Request.Load.Loaders;
using Lace.Request.Tests.Data;
using Lace.Response.ExternalServices;
using Xunit.Extensions;

namespace Lace.Request.Tests
{
    public class lace_entry_point_functional_tests : Specification
    {
        private readonly ILaceRequest _request;
        private IList<LaceExternalServiceResponse> _laceResponses;
        private readonly EntryPoint _entryPoint;
        private readonly ILoadRequestSources _loadRequestSources;

        public lace_entry_point_functional_tests()
        {
            _loadRequestSources = new LaceLicensePlateNumberLoader();
            _request = new LicensePlateNumberSliverAllServicesRequest();
            _entryPoint = new EntryPoint();
        }

        
        public override void Observe()
        {
            _laceResponses = _entryPoint.GetResponsesFromLace(_request);
        }

        [Observation]
        public void requests_for_sliver_to_be_handled_loaded_correclty_for_all_sources_test()
        {


            _laceResponses.Count.ShouldEqual(1);
            _laceResponses[0].Response.ShouldNotBeNull();


            _laceResponses[0].Response.Product.ShouldNotBeNull();
            _laceResponses[0].Response.Product.ProductIsAvailable.ShouldBeTrue();
            

            _laceResponses[0].Response.IvidResponse.ShouldNotBeNull();
            _laceResponses[0].Response.IvidResponseHandled.Handled.ShouldBeTrue();

            _laceResponses[0].Response.IvidTitleHolderResponse.ShouldNotBeNull();
            _laceResponses[0].Response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();

            _laceResponses[0].Response.RgtVinResponse.ShouldNotBeNull();
            _laceResponses[0].Response.RgtVinResponseHandled.Handled.ShouldBeTrue();

            _laceResponses[0].Response.AudatexResponse.ShouldNotBeNull();
            _laceResponses[0].Response.AudatexResponseHandled.Handled.ShouldBeTrue();

        }
    }
}
