using System;
using FluentNHibernate.Testing;
using UserManagement.Domain.Entities;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.PersistenceSpecifications.ValueTypes
{
    public class when_persisting_role : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb();
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<Role>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Value, "test")
                .VerifyTheMappings();
        }
    }
}