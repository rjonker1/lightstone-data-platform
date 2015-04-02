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
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Scans;
using Lace.Test.Helper.Fakes.Lace;
using Lace.Test.Helper.Fakes.Lace.Builder;
using NServiceBus;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Chain
{
    public class when_building_lace_source_chain_for_drivers_license_decryption : Specification
    {
        private IBootstrap _initialize;

        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly IBus _bus;
        private Dictionary<Type, Func<IPointToLaceRequest, IProvideResponseFromLaceDataProviders>> _handlers;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_building_lace_source_chain_for_drivers_license_decryption()
        {
            _bus = Lace.Test.Helper.Builders.Buses.BusFactory.WorkflowBus();
            _request = new DriversLicenseRequestBuilder().ForDriversLicenseScan();
            _buildSourceChain = new FakeSourceChain(_request.GetFromRequest<IAmDriversLicenseRequest>().Package);
            _buildSourceChain.Build();
        }

        public override void Observe()
        {
            _initialize = new FakeLaceInitializer(new Collection<IPointToLaceProvider>(), _request, _bus, _buildSourceChain);
            _initialize.Execute();
        }

        [Observation]
        public void then_drivers_license_source_chain_should_be_loaded_correctly()
        {
            _initialize.DataProviderResponses.ShouldNotBeNull();
            _initialize.DataProviderResponses.Count.ShouldEqual(1);

            _initialize.DataProviderResponses.OfType<IProvideDataFromSignioDriversLicenseDecryption>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromSignioDriversLicenseDecryption>().First().Handled.ShouldBeTrue();
        }
    }
}
