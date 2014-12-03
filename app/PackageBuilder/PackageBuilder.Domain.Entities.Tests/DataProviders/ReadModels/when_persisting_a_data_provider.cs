using System;
using DataPlatform.Shared.Enums;
using FluentNHibernate.Testing;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;
using PackageBuilder.TestHelper.InMemoryPersistence;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Entities.Tests.DataProviders.ReadModels
{
    public class when_persisting_a_data_provider : when_persisting_entities_to_memory
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist_data_provider()
        {
            new PersistenceSpecification<DataProvider>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.DataProviderId, Guid.NewGuid())
                .CheckProperty(c => c.Name, DataProviderName.Ivid)
                .CheckProperty(c => c.Description, "Description")
                .CheckProperty(c => c.Version, 1)
                .CheckProperty(c => c.Owner, "Owner")
                .CheckProperty(c => c.CreatedDate, new DateTime(2014, 01, 01))
                .CheckProperty(c => c.EditedDate, new DateTime(2014, 01, 01))
                .VerifyTheMappings();
        }
    }
}