using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Bus;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Requests
{
    public class when_sending_request_to_lace_entry_point : Specification
    {
        private readonly ILaceRequest _request;
        private IList<LaceExternalSourceResponse> _laceResponses;
        private readonly IEntryPoint _entryPoint;

        public when_sending_request_to_lace_entry_point()
        {
            _request = new LicensePlateRequestBuilder().ForAllSources();

            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);

            _entryPoint = new EntryPointService(publisher);
        }

        public override void Observe()
        {
            _laceResponses = _entryPoint.GetResponsesFromLace(_request);
        }


        [Observation]
        public void lace_request_to_be_loaded_and_responses_to_be_returned_for_all_sources()
        {


            _laceResponses.Count.ShouldEqual(1);
            _laceResponses[0].Response.ShouldNotBeNull();

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
