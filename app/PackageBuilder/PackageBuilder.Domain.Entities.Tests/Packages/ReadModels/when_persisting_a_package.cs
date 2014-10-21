using System;
using FluentNHibernate.Testing;
using PackageBuilder.Domain.Entities.Packages.ReadModels;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Entities.Tests.Packages.ReadModels
{
    public class when_persisting_a_package : when_persisting_entities
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist_package()
        {
            new PersistenceSpecification<Package>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.DataProviderId, Guid.NewGuid())
                .CheckProperty(c => c.Name, "VVi")
                .CheckProperty(c => c.Description, "Description")
                .CheckProperty(c => c.Owner, "Owner")
                .CheckProperty(c => c.Created, new DateTime(2014, 01, 01))
                .CheckProperty(c => c.Edited, new DateTime(2014, 01, 01))
                .VerifyTheMappings();
        }
    }
}