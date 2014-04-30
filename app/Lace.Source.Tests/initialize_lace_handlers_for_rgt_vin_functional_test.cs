using System.Collections.Generic;
using Lace.Request;
using Lace.Response.ExternalServices;
using Lace.Source.Tests.Data;
using Xunit.Extensions;

namespace Lace.Source.Tests
{
    public class initialize_lace_handlers_for_rgt_vin_functional_test : Specification
    {
        private readonly ILaceRequest _request;
        private readonly Initialize _initialize;
        private IList<LaceExternalServiceResponse> _laceResponses;


        public initialize_lace_handlers_for_rgt_vin_functional_test()
        {
            _request = new LicensePlateNumberRgtVinOnlyRequest();
            _initialize = new Initialize(_request);
        }

        public override void Observe()
        {
            _laceResponses = _initialize.LaceResponses;
        }

        [Observation]
        public void lace_functional_test_rgt_vin_response_should_be_handled_test()
        {
            _laceResponses[0].Response.RgtVinResponseHandled.Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_functional_test_rgt_vin_response_shuould_not_be_null_test()
        {
            _laceResponses[0].Response.RgtVinResponse.ShouldNotBeNull();
        }
    }
}
