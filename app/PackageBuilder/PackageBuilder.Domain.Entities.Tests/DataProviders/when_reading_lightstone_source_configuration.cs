﻿using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Entities.Tests.DataProviders
{
    public class when_reading_lightstone_source_configuration : Specification
    {
        private SourceConfiguration _sourceConfiguration;
        public override void Observe()
        {
            _sourceConfiguration = new SourceConfiguration(DataProviderName.Lightstone);
        }

        [Observation]
        public void should_set_connection_string()
        {
            _sourceConfiguration.ConnectionString.ShouldNotBeNull();
            _sourceConfiguration.ConnectionString.ShouldNotBeEmpty();
        }
    }
}