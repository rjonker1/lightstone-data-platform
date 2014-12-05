using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Bus;
using Lace.Test.Helper.Fakes.Lace;
using Lace.Test.Helper.Fakes.Lace.Builder;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Chain
{
    public class when_building_lace_source_chain_for_license_plate_number_search : Specification
    {

        private IBootstrap _initialize;

        private readonly ILaceRequest _request;
        private readonly ISendMonitoringMessages _laceEvent;
        private Dictionary<Type, Func<ILaceRequest, IProvideResponseFromLaceDataProviders>> _handlers;

        private readonly IBuildSourceChain _buildSourceChain;

        public when_building_lace_source_chain_for_license_plate_number_search()
        {
            //var bus = new FakeBus();
            //var publisher = new Workflow.RabbitMQ.Publisher(bus);

            _request = new LicensePlateRequestBuilder().ForAllSources();

           // _laceEvent = new PublishLaceEventMessages(publisher, _request.RequestAggregation.AggregateId);
            _buildSourceChain = new FakeSourceChain(_request.Package.Action);
            _buildSourceChain.Build();
        }

        public override void Observe()
        {
            _initialize = new FakeLaceInitializer(new LaceResponse(), _request, _laceEvent, _buildSourceChain);
            _initialize.Execute();
        }


        [Observation]
        public void lace_source_in_chain_to_be_loaded_correclty()
        {

            _initialize.LaceResponses.Count.ShouldEqual(1);
            _initialize.LaceResponses[0].Response.ShouldNotBeNull();

            _initialize.LaceResponses[0].Response.IvidResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.IvidResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.LightstoneResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.LightstoneResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.IvidTitleHolderResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.IvidTitleHolderResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.RgtVinResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.RgtVinResponseHandled.Handled.ShouldBeTrue();

            _initialize.LaceResponses[0].Response.AudatexResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.AudatexResponseHandled.Handled.ShouldBeTrue();

        }

    }
}
