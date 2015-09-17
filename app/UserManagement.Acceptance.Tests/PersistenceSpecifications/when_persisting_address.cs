using System;
using FluentNHibernate.Testing;
using UserManagement.Domain.Entities;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.PersistenceSpecifications
{
    public class when_persisting_address : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb();
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<Address>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Line1, "Line1")
                .CheckProperty(c => c.Line2, "Line2")
                .CheckProperty(c => c.Suburb, "Suburb")
                .CheckProperty(c => c.City, "City")
                .CheckProperty(c => c.Country, new Country("South Africa"))
                .CheckProperty(c => c.PostalCode, "PostalCode")
                .CheckReference(c => c.Province, new Province("Gauteng"))
                .VerifyTheMappings();
        }
    }
}