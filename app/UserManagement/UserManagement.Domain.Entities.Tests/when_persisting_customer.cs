using System;
using System.Collections.Generic;
using FluentNHibernate.Testing;
using UserManagement.Domain.Enums;
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
            var customer = new Customer("Name");
            var paymentType = new PaymentType("PaymentType");
            var physicalAddress = new Address(AddressType.Physical, "Line1", "Line2", "PostalCode", "City", "Country", "PostalCode", new Province("Limpopo"));
            var postalAddress = new Address(AddressType.Postal, "Line1", "Line2", "PostalCode", "City", "Country", "PostalCode", new Province("Gauteng"));
            var billing = new Billing("ContactNumber", "ContactPerson", "RegistrationNumber", DateTime.Now, "PastelId", "VatNumber", paymentType);
            var roles = new HashSet<Role>{new Role("Role")};
            var user = new User("FirstName", "LastName", "IdNumber", "ContactNumber", "UserName", "Password", false, UserType.Internal, roles);
            new PersistenceSpecification<Customer>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Name, "Name")
                .CheckReference(c => c.AccountOwner, user)
                .CheckReference(c => c.Billing, billing)
                .CheckReference(c => c.CommercialState, new CommercialState("CommercialState"))
                //.CheckReference(c => c.PlatformStatus, new PlatformStatus("PlatformStatus", PlatformStatusType.Activated))
                .CheckReference(c => c.ContactDetail, new ContactDetail("Name", "ContactName", "EmailAddress", physicalAddress, postalAddress))
                .CheckReference(c => c.CreateSource, new CreateSource("CreateSource", CreateSourceType.Web))
                .CheckComponentList(c => c.CustomerUsers, new HashSet<User>{ user })
                .CheckComponentList(c => c.Contracts, new HashSet<Contract> { new Contract(DateTime.Now, "Name", "Detail", "By", DateTime.Now, "RegisteredName", "Reg#", new ContractType("Type"), new EscalationType("Esc"), new ContractDuration("Dur")) })
                .CheckComponentList(c => c.Industries, new HashSet<CustomerIndustry> { new CustomerIndustry(customer, Guid.NewGuid())})
                .VerifyTheMappings(customer);
        }
    }
}