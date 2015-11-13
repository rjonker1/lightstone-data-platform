using System;
using FluentNHibernate.Testing;
using UserManagement.Domain.Enums;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Domain.Entities.Tests
{
    public class when_persisting_address : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<Address>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Type, AddressType.Physical)
                .CheckProperty(c => c.Line1, "Line1")
                .CheckProperty(c => c.Line2, "Line2")
                .CheckProperty(c => c.Suburb, "Suburb")
                .CheckProperty(c => c.City, "City")
                .CheckProperty(c => c.Country, "Country")
                .CheckProperty(c => c.PostalCode, "PostalCode")
                .CheckReference(c => c.Province, new Province("Gauteng"))
                .VerifyTheMappings();
        }
    }
}