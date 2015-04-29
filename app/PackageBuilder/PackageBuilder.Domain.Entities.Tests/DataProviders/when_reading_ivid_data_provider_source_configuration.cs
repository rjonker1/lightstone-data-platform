using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Entities.Tests.DataProviders
{
    public class when_reading_ivid_data_provider_source_configuration : Specification
    {
        private SourceConfiguration _sourceConfiguration;
        public override void Observe()
        {
            _sourceConfiguration = new SourceConfiguration(DataProviderName.Ivid);
        }

        [Observation]
        public void should_set_url()
        {
            _sourceConfiguration.Url.ShouldNotBeNull();
            _sourceConfiguration.Url.ShouldNotBeEmpty();
        }

        [Observation]
        public void should_set_username()
        {
            _sourceConfiguration.Username.ShouldNotBeNull();
            _sourceConfiguration.Username.ShouldNotBeEmpty();
        }

        [Observation]
        public void should_set_password()
        {
            _sourceConfiguration.Password.ShouldNotBeNull();
            _sourceConfiguration.Password.ShouldNotBeEmpty();
        }
    }
}
