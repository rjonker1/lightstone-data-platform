using System;
using FluentNHibernate.Testing;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.PersistenceSpecifications.Industries.Read
{
    public class when_persisting_a_industry : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb();
        }

        [Observation]
        public void should_persist_industry()
        {
            new PersistenceSpecification<Industry>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Name, "Name")
                .VerifyTheMappings();
        }
    }
}