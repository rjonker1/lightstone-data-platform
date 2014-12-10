using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using NServiceBus;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Requests
{
    public class when_sending_request_to_lace_entry_point : Specification
    {
        private readonly ILaceRequest _request;
        private IList<LaceExternalSourceResponse> _responses;
        private readonly IEntryPoint _entryPoint;
        private readonly IBus _bus;

        public when_sending_request_to_lace_entry_point()
        {
            _bus = BusFactory.NServiceRabbitMqBus();
            _request = new LicensePlateRequestBuilder().ForAllSources();
            _entryPoint = new EntryPointService(_bus);
        }

        public override void Observe()
        {
            _responses = _entryPoint.GetResponsesFromLace(_request);
        }

        [Observation]
        public void lace_request_to_be_loaded_and_responses_to_be_returned_for_all_sources()
        {
            _responses.Count.ShouldEqual(1);
            _responses[0].Response.ShouldNotBeNull();

            _responses[0].Response.IvidResponse.ShouldNotBeNull();
            _responses[0].Response.IvidResponseHandled.Handled.ShouldBeTrue();

            _responses[0].Response.IvidTitleHolderResponse.ShouldNotBeNull();
            _responses[0].Response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();

            _responses[0].Response.RgtVinResponse.ShouldNotBeNull();
            _responses[0].Response.RgtVinResponseHandled.Handled.ShouldBeTrue();

            _responses[0].Response.RgtResponse.ShouldNotBeNull();
            _responses[0].Response.RgtResponseHandled.Handled.ShouldBeTrue();

            _responses[0].Response.LightstoneResponse.ShouldNotBeNull();
            _responses[0].Response.LightstoneResponseHandled.Handled.ShouldBeTrue();

            _responses[0].Response.AudatexResponse.ShouldNotBeNull();
            _responses[0].Response.AudatexResponseHandled.Handled.ShouldBeTrue();

        }
    }
}
