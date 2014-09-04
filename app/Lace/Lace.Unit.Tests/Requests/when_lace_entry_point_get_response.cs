using System.Collections.Generic;
using Lace.Request;
using Lace.Request.Entry;
using Lace.Response;
using Lace.Response.ExternalServices;
using Lace.Test.Helper.Fakes.Lace.EntryPoint;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Requests
{
    public class when_lace_entry_point_get_response : Specification
    {
        private readonly IEntryPoint _entryPoint;
        private readonly ILaceResponse _response;
        private readonly ILaceRequest _request;
        private IList<LaceExternalServiceResponse> _laceResponse;

        public when_lace_entry_point_get_response()
        {
            _entryPoint = new FakeEntryPoint();
            _request = new LicensePlateNumberSliverAllServicesRequest();
        }

        public override void Observe()
        {
            _laceResponse = _entryPoint.GetResponsesFromLace(_request);
        }

        [Observation]
        public void lace_entry_point_get_response_must_not_be_null()
        {
            _laceResponse.ShouldNotBeNull();
        }

        [Observation]
        public void lace_entry_point_get_response_must_be_availble()
        {
            _laceResponse.Count.ShouldEqual(1);
        }
        
    }
}
