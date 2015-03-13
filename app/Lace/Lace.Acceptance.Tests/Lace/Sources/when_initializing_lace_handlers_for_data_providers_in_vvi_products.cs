using System;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_data_providers_in_vvi_products : Specification
    {
        private readonly ILaceRequest _request;
        private readonly IBus _monitoring;
        private readonly IBootstrap _initialize;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_initializing_lace_handlers_for_data_providers_in_vvi_products()
        {
            _monitoring = BusFactory.MonitoringBus();
            _request = new LicensePlateRequestBuilder().ForAllSources();
            _buildSourceChain = new CreateSourceChain(_request.Package);
            _buildSourceChain.Build();
            _initialize = new Initialize(new Collection<IPointToLaceProvider>(), _request, _monitoring,
                _buildSourceChain);
        }


        public override void Observe()
        {
            _initialize.Execute();
        }

        [Observation]
        public void lace_ivid_response_for_vvi_product_should_not_be_null()
        {
            _initialize.DataProviderResponses.ShouldNotBeNull();
            _initialize.DataProviderResponses.Count.ShouldEqual(6);

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
