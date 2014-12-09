using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Test.Helper.Fakes.Lace.EntryPoint;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Requests
{
    public class when_lace_entry_point_get_response : Specification
    {
        private readonly IEntryPoint _entryPoint;
        private readonly IProvideResponseFromLaceDataProviders _response;
        private readonly ILaceRequest _request;
        private IList<LaceExternalSourceResponse> _laceResponse;

        public when_lace_entry_point_get_response()
        {
            _entryPoint = new FakeEntryPoint();
            _request = new LicensePlateNumberAllDataProvidersRequest();
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
