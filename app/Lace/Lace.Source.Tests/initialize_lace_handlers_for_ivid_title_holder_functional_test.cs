using System.Collections.Generic;
using Lace.Request;
using Lace.Request.Load;
using Lace.Request.Load.Loaders;
using Lace.Response.ExternalServices;
using Lace.Source.Tests.Data;
using Xunit.Extensions;

namespace Lace.Source.Tests
{
    public class initialize_lace_handlers_for_ivid_title_holder_functional_test : Specification
    {

        private readonly ILaceRequest _request;
        private readonly Initialize _initialize;
        private IList<LaceExternalServiceResponse> _laceResponses;
        private readonly ILoadRequestSources _loadRequestSources;

        public initialize_lace_handlers_for_ivid_title_holder_functional_test()
        {
            _loadRequestSources = new LaceLicensePlateNumberLoader();
            _request = new LicensePlateNumberIvidTitleHolderOnlyRequest();
            _initialize = new Initialize(_request, _loadRequestSources);
        }

        public override void Observe()
        {
            _laceResponses = _initialize.LaceResponses;
        }

        [Observation]
        public void lace_functional_test_ivid_title_holder_response_should_be_handled_test()
        {
            _laceResponses[0].Response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_functional_test_ivid_title_holder_response_shuould_not_be_null_test()
        {
            _laceResponses[0].Response.IvidTitleHolderResponse.ShouldNotBeNull();
        }

    }
}
