using System.Collections.Generic;
using Lace.Request.Entry;
using Lace.Request.Tests.Data;
using Lace.Request.Tests.Data.EntryPointData;
using Lace.Response;
using Lace.Response.ExternalServices;
using Xunit.Extensions;

namespace Lace.Request.Tests.EntryPointTests
{
    public class lace_entry_point_get_response_tests : Specification
    {

        private readonly IEntryPoint _entryPoint;
        private readonly ILaceResponse _response;
        private readonly ILaceRequest _request;
        private IList<LaceExternalServiceResponse> _laceResponse;

        public lace_entry_point_get_response_tests()
        {
            _entryPoint = new MockEntryPoint();
            _request = new LicensePlateNumberSliverAllServicesRequest();
        }

        public override void Observe()
        {
            _laceResponse = _entryPoint.GetResponsesFromLace(_request);
        }

        [Observation]
        public void lace_entry_point_get_response_must_not_be_null_test()
        {
            _laceResponse.ShouldNotBeNull();
        }

        [Observation]
        public void lace_entry_point_get_response_must_be_availble_test()
        {
            _laceResponse.Count.ShouldEqual(1);
        }
    }
}
