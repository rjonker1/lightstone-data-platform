using System;
using System.Collections.Generic;
using FluentNHibernate.Testing;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Domain.Entities.Tests
{
    public class when_persisting_customer : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist()
        {
            var paymentType = new PaymentType("PaymentType");
            var physicalAddress = new Address("Type", "Line1", "Line2", "PostalCode","City","Country", "PostalCode", new Province("Gauteng"));
            var postalAddress = new Address("Type", "Line1", "Line2", "PostalCode","City","Country", "PostalCode", new Province("Gauteng"));
            var billing = new Billing("ContactNumber", "ContactPerson", "RegistrationNumber", DateTime.Now, "PastelId", "VatNumber", paymentType);
            var roles = new HashSet<Role>{new Role("Role")};
            var userType = new UserType("UserType");
            var user = new User("FirstName", "LastName", "IdNumber", "ContactNumber", "UserName", "Password", false, userType, roles);
            new PersistenceSpecification<Customer>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Name, "FirstName")
                .CheckProperty(c => c.AccountOwnerName, "LastName")
                .CheckReference(c => c.Billing, billing)
                .CheckReference(c => c.CommercialState, new CommercialState(""))
                .CheckReference(c => c.CreateSource, new CreateSource("CommercialState"))
                .CheckReference(c => c.PlatformStatus, new PlatformStatus("PlatformStatus"))
                .CheckReference(c => c.ContactDetail, new ContactDetail("Name", "ContactName", "EmailAddess", "Tel", physicalAddress, postalAddress))
                .CheckComponentList(c => c.Users, new HashSet<User>{ user })
                .VerifyTheMappings();
        }
    }
}