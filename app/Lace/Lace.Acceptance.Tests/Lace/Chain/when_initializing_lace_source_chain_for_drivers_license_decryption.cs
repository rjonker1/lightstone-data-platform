using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Test.Helper.Builders.Scans;
using Lace.Test.Helper.Builders.Buses;
using NServiceBus;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Chain
{
    public class when_initializing_lace_source_chain_for_drivers_license_decryption : Specification
    {
        private IBootstrap _initialize;
        private readonly ILaceRequest _request;
        private readonly IBus _monitoring;
        private readonly IBuildSourceChain _buildSourceChain;

        public when_initializing_lace_source_chain_for_drivers_license_decryption()
        {
            _monitoring = BusFactory.MonitoringBus();
            _request = new DriversLicenseRequestBuilder().ForDriversLicenseScan();
            _buildSourceChain = new CreateSourceChain(_request.Package);
            _buildSourceChain.Build();
        }

        public override void Observe()
        {
            _initialize = new Initialize(new LaceResponse(), _request, _monitoring, _buildSourceChain);
            _initialize.Execute();
        }

        [Observation]
        public void lace_data_providers_for_drivers_license_decryption_should_loaded_correclty()
        {
            _initialize.LaceResponses.Count.ShouldEqual(1);
            _initialize.LaceResponses[0].Response.ShouldNotBeNull();

            _initialize.LaceResponses[0].Response.SignioDriversLicenseDecryptionResponse.ShouldNotBeNull();
            _initialize.LaceResponses[0].Response.SignioDriversLicenseDecryptionResponseHandled.Handled.ShouldBeTrue();

        }
    }
}
