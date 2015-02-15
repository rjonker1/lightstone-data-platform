using System;
using FluentNHibernate.Testing;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Domain.Entities.Tests
{
    public class when_persisting_package : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<Package>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Name, "Name")
                .CheckProperty(c => c.Version, "Version")
                .CheckProperty(c => c.IsActivated, true)
                .VerifyTheMappings();
        }
    }
}