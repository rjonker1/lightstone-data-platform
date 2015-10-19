using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Test.Helper.Fakes.Lace.EntryPoint;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Requests
{
    public class when_lace_entry_point_get_response : Specification
    {
        private readonly IEntryPoint _entryPoint;
        private ICollection<IPointToLaceProvider> _response;
        private readonly ICollection<IPointToLaceRequest> _request;

        public when_lace_entry_point_get_response()
        {
            _entryPoint = new FakeEntryPoint();
            _request = new[] {new LicensePlateNumberAllDataProvidersRequest()};
        }

        public override void Observe()
        {
            _response = _entryPoint.GetResponses(_request);
        }

        [Observation]
        public void lace_entry_point_get_response_must_not_be_null()
        {
            _response.ShouldNotBeNull();
        }

        [Observation]
        public void lace_entry_point_get_response_must_be_availble()
        {
            _response.Count.ShouldEqual(8);
        }
    }
}
