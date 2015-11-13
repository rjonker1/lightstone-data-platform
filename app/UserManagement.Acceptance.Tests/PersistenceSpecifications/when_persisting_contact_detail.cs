using System;
using FluentNHibernate.Testing;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enums;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.PersistenceSpecifications
{
    public class when_persisting_contact_detail : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb();
        }

        [Observation]
        public void should_persist()
        {
            var physicalAddress = new Address("Line1", "Line2", "PostalCode", "City", new Country("South Africa"), "PostalCode", new Province("Gauteng"));
            var postalAddress = new Address("Line1", "Line2", "PostalCode", "City", new Country("Botswana"), "PostalCode", new Province("Limpopo"));
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