﻿using System.Collections.Generic;
using Lace.Request;
using Lace.Response.ExternalServices;
using Lace.Source.Tests.Data;
using Xunit.Extensions;

namespace Lace.Source.Tests
{
    public class initialize_lace_handlers_for_audatex_request_functional_test : Specification
    {

        private readonly ILaceRequest _request;
        private readonly Initialize _initialize;
        private IList<LaceExternalServiceResponse> _laceResponses;

        public initialize_lace_handlers_for_audatex_request_functional_test()
        {
            _request = new LicensePlateNumberAudatexOnlyRequest();
            _initialize = new Initialize(_request);
        }


        public override void Observe()
        {
            _laceResponses = _initialize.LaceResponses;
        }

        [Observation]
        public void lace_functional_test_response_for_audatex_to_be_returned_should_be_one_test()
        {
            _laceResponses.Count.ShouldEqual(1);
        }


        [Observation]
        public void lace_functional_test_audatex_response_should_be_handled_test()
        {
            _laceResponses[0].Response.AudatexResponseHandled.Handled.ShouldEqual(true);
        }

        [Observation]
        public void lace_functional_test_audatex_response_shuould_not_be_null_test()
        {
            _laceResponses[0].Response.AudatexResponse.ShouldNotBeNull();
        }
    }
}
