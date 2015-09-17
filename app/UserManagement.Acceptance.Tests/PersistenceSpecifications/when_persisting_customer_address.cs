using System;
using FluentNHibernate.Testing;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enums;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.PersistenceSpecifications
{
    public class when_persisting_customer_address : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb(false);
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<CustomerAddress>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckReference(c => c.Customer, new Customer("Name"))
                .CheckReference(c => c.Address, new Address("Line1", "Line2", "Suburb", "City", new Country("South Africa"), "Postal code", new Province("Gauteng")))
                .CheckProperty(c => c.AddressType, AddressType.Physical)
                .VerifyTheMappings();
        }
    }
}