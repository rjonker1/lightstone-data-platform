using System;
using FluentNHibernate.Testing;
using PackageBuilder.Domain.Entities.Packages.ReadModels;
using PackageBuilder.TestHelper.InMemoryPersistence;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Entities.Tests.Packages.ReadModels
{
    public class when_persisting_a_package : when_persisting_entities_to_memory
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist_package()
        {
            new PersistenceSpecification<Package>(Session)
                .CheckProperty(c => c.PackageId, Guid.NewGuid())
                .CheckProperty(c => c.Name, "VVi")
                .CheckProperty(c => c.Description, "Description")
                .CheckProperty(c => c.Version, 1)
                .CheckProperty(c => c.Owner, "Owner")
                .CheckProperty(c => c.CreatedDate, new DateTime(2014, 01, 01))
                .CheckProperty(c => c.EditedDate, new DateTime(2014, 01, 01))
                .VerifyTheMappings();
        }
    }
}