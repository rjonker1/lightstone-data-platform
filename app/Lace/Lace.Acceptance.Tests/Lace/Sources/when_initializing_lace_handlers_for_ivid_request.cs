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
    public class when_initializing_lace_handlers_for_ivid_request : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private readonly IBootstrap _initialize;
        private IList<LaceExternalServiceResponse> _laceResponses;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_initializing_lace_handlers_for_ivid_request()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            
            _request = new LicensePlateRequestBuilder().ForIvid();

            _laceEvent = new PublishLaceEventMessages(publisher,_request.RequestAggregation.AggregateId);


            _buildSourceChain = new CreateSourceChain(_request.Package.Action);
            _buildSourceChain.Build();


            _initialize = new Initialize(new LaceResponse(), _request, _laceEvent, _buildSourceChain);
        }


        public override void Observe()
        {
            _initialize.Execute();
            _laceResponses = _initialize.LaceResponses;
        }

        [Observation]
        public void lace_response_to_be_returned_should_be_one()
        {
            _laceResponses.Count.ShouldEqual(1);
        }


        [Observation]
        public void lace_ivid_response_should_be_handled()
        {
            _laceResponses[0].Response.IvidResponseHandled.Handled.ShouldEqual(true);
        }

        [Observation]
        public void lace_ivid_response_shuould_not_be_null()
        {
            _laceResponses[0].Response.IvidResponse.ShouldNotBeNull();
        }
    }
}
