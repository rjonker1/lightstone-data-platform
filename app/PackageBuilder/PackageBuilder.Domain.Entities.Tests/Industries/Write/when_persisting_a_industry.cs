using System;
using FluentNHibernate.Testing;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Entities.Tests.Industries.Write
{
    public class when_persisting_a_industry : when_persisting_entities_to_memory
    {
        public override void Observe()
        {
            base.Observe();
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