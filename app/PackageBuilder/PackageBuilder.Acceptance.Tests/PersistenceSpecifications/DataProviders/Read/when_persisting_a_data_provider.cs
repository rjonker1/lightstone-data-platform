using System;
using DataPlatform.Shared.Enums;
using FluentNHibernate.Testing;
using PackageBuilder.Domain.Entities.DataProviders.Read;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.PersistenceSpecifications.DataProviders.Read
{
    public class when_persisting_a_data_provider : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb();
        }

        [Observation]
        public void should_persist_data_provider()
        {
            new PersistenceSpecification<DataProvider>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.DataProviderId, Guid.NewGuid())
                .CheckProperty(c => c.Name, DataProviderName.IVIDVerify_E_WS)
                .CheckProperty(c => c.Description, "Description")
                .CheckProperty(c => c.Version, 1)
                .CheckProperty(c => c.Owner, "Owner")
                .CheckProperty(c => c.CreatedDate, new DateTime(2014, 01, 01))
                .CheckProperty(c => c.EditedDate, new DateTime(2014, 01, 01))
                .VerifyTheMappings();
        }
    }
}