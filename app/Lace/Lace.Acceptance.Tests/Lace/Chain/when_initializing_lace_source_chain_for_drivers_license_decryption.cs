using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Scans;
using Lace.Test.Helper.Builders.Buses;
using NServiceBus;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Chain
{
    public class when_initializing_lace_source_chain_for_drivers_license_decryption : Specification
    {
        private IBootstrap _initialize;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly IBus _monitoring;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_initializing_lace_source_chain_for_drivers_license_decryption()
        {
            _monitoring = BusFactory.MonitoringBus();
            _request = new DriversLicenseRequestBuilder().ForDriversLicenseScan();
            _buildSourceChain = new CreateSourceChain(_request.GetFromRequest<IAmDriversLicenseRequest>().Package);
            _buildSourceChain.Build();
        }

        public override void Observe()
        {
            _initialize = new Initialize(new Collection<IPointToLaceProvider>(), _request, _monitoring, _buildSourceChain);
            _initialize.Execute();
        }

        [Observation]
        public void lace_data_providers_for_drivers_license_decryption_should_loaded_correclty()
        {
            _initialize.DataProviderResponses.ShouldNotBeNull();
            _initialize.DataProviderResponses.Count.ShouldEqual(1);

            _initialize.DataProviderResponses.OfType<IProvideDataFromSignioDriversLicenseDecryption>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromSignioDriversLicenseDecryption>().First().Handled.ShouldBeTrue();

        }
    }
}
