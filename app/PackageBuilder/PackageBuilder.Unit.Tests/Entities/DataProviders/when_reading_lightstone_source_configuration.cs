using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.Entities.DataProviders
{
    public class when_reading_lightstone_source_configuration : Specification
    {
        private SourceConfiguration _sourceConfiguration;
        public override void Observe()
        {
            _sourceConfiguration = new SourceConfiguration(DataProviderName.LightstoneAuto);
        }

        [Observation]
        public void should_set_connection_string()
        {
            _sourceConfiguration.ConnectionString.ShouldNotBeNull();
            _sourceConfiguration.ConnectionString.ShouldNotBeEmpty();
        }
    }
}