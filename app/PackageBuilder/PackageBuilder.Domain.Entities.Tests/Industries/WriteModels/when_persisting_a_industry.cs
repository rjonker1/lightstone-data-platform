using System;
using FluentNHibernate.Testing;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.TestHelper.InMemoryPersistence;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Entities.Tests.Industries.WriteModels
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