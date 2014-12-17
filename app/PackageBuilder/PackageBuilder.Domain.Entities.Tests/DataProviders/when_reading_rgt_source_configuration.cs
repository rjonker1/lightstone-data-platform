﻿using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Entities.Tests.DataProviders
{
    public class when_reading_rgt_source_configuration : Specification
    {
        private SourceConfiguration _sourceConfiguration;
        public override void Observe()
        {
            _sourceConfiguration = new SourceConfiguration(DataProviderName.Rgt);
        }

        [Observation]
        public void should_set_connection_string()
        {
            _sourceConfiguration.ConnectionString.ShouldNotBeNull();
            _sourceConfiguration.ConnectionString.ShouldNotBeEmpty();
        }
    }
}