using System.Collections.Generic;
using Lace.Builder;
using Lace.Builder.Factory;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Response.ExternalServices;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Fakes.Bus;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_audatex_request : Specification
    {

        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private readonly IBootstrap  _initialize;
        private IList<LaceExternalServiceResponse> _laceResponses;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_initializing_lace_handlers_for_audatex_request()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);

            _request = new LicensePlateRequestBuilder().ForAudatex();

            _buildSourceChain = new CreateSourceChain(_request.Package.Action);
            _buildSourceChain.Build();


            _initialize = new Initialize(new LaceResponseBuilder().WithIvidResponseHandled(), _request, _laceEvent, _buildSourceChain);
        }


        public override void Observe()
        {
            _initialize.Execute();
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
