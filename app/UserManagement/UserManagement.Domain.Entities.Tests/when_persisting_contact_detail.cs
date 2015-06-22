using System;
using FluentNHibernate.Testing;
using UserManagement.Domain.Enums;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Domain.Entities.Tests
{
    public class when_persisting_contact_detail : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist()
        {
            var physicalAddress = new Address(AddressType.Physical, "Line1", "Line2", "PostalCode", "City", new Country("South Africa"), "PostalCode", new Province("Gauteng"));
            var postalAddress = new Address(AddressType.Postal, "Line1", "Line2", "PostalCode", "City", new Country("South Africa"), "PostalCode", new Province("Gauteng"));
            new PersistenceSpecification<ContactDetail>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.ContactPerson, "ContactPerson")
                .CheckProperty(c => c.ContactNumber, "ContactNumber")
                .CheckProperty(c => c.EmailAddress, "EmailAddress")
                .CheckReference(c => c.PhysicalAddress, physicalAddress)
                .CheckReference(c => c.PostalAddress, postalAddress)
                .VerifyTheMappings();
        }
    }
}