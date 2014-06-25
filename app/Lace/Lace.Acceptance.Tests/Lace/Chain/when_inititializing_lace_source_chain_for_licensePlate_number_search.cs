using System;
using System.Collections.Generic;
using Lace.Builder;
using Lace.Builder.Factory;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Response;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Fakes.Lace;
using Lace.Test.Helper.Fakes.Lace.Builder;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Chain
{
    public class when_inititializing_lace_source_chain_for_licensePlate_number_search : Specification
    {
        private IBootstrap _initialize;

        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private Dictionary<Type, Func<ILaceRequest, ILaceResponse>> _handlers;

        private readonly IBuildSourceChain _buildSourceChain;

        public when_inititializing_lace_source_chain_for_licensePlate_number_search()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _request = new LicensePlateRequestBuilder().ForAllSources();

            _buildSourceChain = new FakeSourceChain();
            _buildSourceChain.Default(_request.Package.Action);
        }

        public override void Observe()
        {
            _initialize = new FakeLaceInitializer(new LaceResponse(), _request, _laceEvent, _buildSourceChain);
            _initialize.Execute();
        }

        [Observation]
        public void lace_services_for_sliver_to_be_handled_loaded_correclty()
        {

            _initialize.LaceResponses.Count.ShouldEqual(1);
            _initialize.LaceResponses[0].Response.ShouldNotBeNull();

            //_initialize.LaceResponses[0].Response.Product.ShouldNotBeNull();
            //_initialize.LaceResponses[0].Response.Product.ProductIsAvailable.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.IvidResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.IvidResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.IvidTitleHolderResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.RgtVinResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.RgtVinResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.AudatexResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.AudatexResponseHandled.Handled.ShouldBeTrue();

        }
    }
}
