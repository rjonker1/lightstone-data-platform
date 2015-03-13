using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using NServiceBus;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Chain
{
    public class when_inititializing_lace_source_chain_for_licensePlate_number_search : Specification
    {
        private IBootstrap _initialize;

        private readonly ILaceRequest _request;
        private readonly IBus _monitoring;
        private Dictionary<Type, Func<ILaceRequest, IProvideResponseFromLaceDataProviders>> _handlers;

        private readonly IBuildSourceChain _buildSourceChain;

        public when_inititializing_lace_source_chain_for_licensePlate_number_search()
        {

            _monitoring = BusFactory.MonitoringBus();
            _request = new LicensePlateRequestBuilder().ForAllSources();
            _buildSourceChain = new CreateSourceChain(_request.Package);
            _buildSourceChain.Build();
        }

        public override void Observe()
        {
            _initialize = new Initialize(new Collection<IPointToLaceProvider>(), _request, _monitoring, _buildSourceChain);
            _initialize.Execute();
        }

        [Observation]
        public void lace_data_providers_for_VVI_product_must_be_handled_loaded_correclty()
        {
            _initialize.DataProviderResponses.ShouldNotBeNull();
            _initialize.DataProviderResponses.Count.ShouldEqual(1);

            _initialize.DataProviderResponses.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();

            _initialize.DataProviderResponses.OfType<IProvideDataFromIvidTitleHolder>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromIvidTitleHolder>().First().Handled.ShouldBeTrue();

            _initialize.DataProviderResponses.OfType<IProvideDataFromRgtVin>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromRgtVin>().First().Handled.ShouldBeTrue();

            _initialize.DataProviderResponses.OfType<IProvideDataFromRgt>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromRgt>().First().Handled.ShouldBeTrue();

            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();

            _initialize.DataProviderResponses.OfType<IProvideDataFromAudatex>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromAudatex>().First().Handled.ShouldBeTrue();

        }
    }
}
