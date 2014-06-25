using System.Collections.Generic;
using Lace.Builder;
using Lace.Builder.Factory;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Response.ExternalServices;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Bus;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_ivid_title_holder : Specification
    {

        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private readonly Initialize _initialize;
        private IList<LaceExternalServiceResponse> _laceResponses;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_initializing_lace_handlers_for_ivid_title_holder()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);

            _request = new LicensePlateRequestBuilder().ForIvidTitleHolder();


            _buildSourceChain = new CreateSourceChain();
            _buildSourceChain.Default(_request.Package.Action);


            _initialize = new Initialize(new LaceResponse(), _request, _laceEvent, _buildSourceChain);
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
