using System;
using System.Collections.Generic;
using Lace.Events;
using Lace.Events.Messages.Publish;
using Lace.Request;
using Lace.Request.Load;
using Lace.Response;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Fakes.Lace;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Chain
{
    public class when_inititializing_lace_source_chain_for_licensePlate_number_search : Specification
    {
        private FakeLaceInitializer _initialize;

        private readonly ILaceRequest _request;
        private readonly ILaceEvent _laceEvent;
        private Dictionary<Type, Func<ILaceRequest, ILaceResponse>> _handlers;
        private readonly ILoadRequestSources _loadRequestSources;

        public when_inititializing_lace_source_chain_for_licensePlate_number_search()
        {
            var bus = new FakeBus();
            var publisher = new Workflow.RabbitMQ.Publisher(bus);
            _laceEvent = new PublishLaceEventMessages(publisher);
            _request = new LicensePlateRequestBuilder().ForAllSources();
            _loadRequestSources = new FakeLaceLoader();
        }

        public override void Observe()
        {
            _initialize = new FakeLaceInitializer(_request, _loadRequestSources, _laceEvent);
        }

        [Observation]
        public void lace_services_for_sliver_to_be_handled_loaded_correclty()
        {

            _initialize.LaceResponses.Count.ShouldEqual(1);
            _initialize.LaceResponses[0].Response.ShouldNotBeNull();

            _initialize.LaceResponses[0].Response.Product.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.Product.ProductIsAvailable.ShouldBeTrue();

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
