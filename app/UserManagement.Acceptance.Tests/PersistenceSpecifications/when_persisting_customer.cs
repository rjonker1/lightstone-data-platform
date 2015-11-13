using System;
using System.Collections.Generic;
using FluentNHibernate.Testing;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enums;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Acceptance.Tests.PersistenceSpecifications
{
    public class when_persisting_customer : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb(false);
        }

        [Observation]
        public void should_persist()
        {
            var customer = new Customer("Name");
            var physicalAddress = new Address("Line1", "Line2", "PostalCode", "City", new Country("South Africa"), "PostalCode", new Province("Limpopo"));
            var postalAddress = new Address("Line1", "Line2", "PostalCode", "City", new Country("Botswana"), "PostalCode", new Province("Gauteng"));
            var billing = new Billing("ContactNumber", "ContactPerson", "RegistrationNumber", DateTime.UtcNow, "PastelId", "VatNumber", PaymentType.DebitOrder);
            var roles = new HashSet<Role>{new Role("Role")};
            var user = new User("FirstName", "LastName", "IdNumber", "ContactNumber", "UserName", "Password", false, UserType.Internal, roles);
            new PersistenceSpecification<Customer>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Name, "Name")
                .CheckReference(c => c.AccountOwner, user)
                .CheckReference(c => c.Billing, billing)
                .CheckReference(c => c.CommercialState, new CommercialState("CommercialState"))
                .CheckProperty(c => c.CreateSource, CreateSourceType.Web)
                .CheckList(c => c.CustomerUsers, new HashSet<CustomerUser> { new CustomerUser(customer, new User { Id = Guid.NewGuid(), UserName = "UserName1" }, true) })
                .CheckList(c => c.Contracts, new HashSet<Contract> { new Contract(DateTime.UtcNow, "Name", "Detail", "By", DateTime.UtcNow, "RegisteredName", "Reg#", new ContractType("Type"), EscalationType.AnnualPercentageAllProducts, ContractDuration.Custom) })
                .CheckList(c => c.Industries, new HashSet<CustomerIndustry> { new CustomerIndustry(customer, Guid.NewGuid()) })
                .CheckList(c => c.Addresses, new HashSet<CustomerAddress> { new CustomerAddress(customer, physicalAddress, AddressType.Physical), new CustomerAddress(customer, postalAddress, AddressType.Postal) })
                .CheckList(c => c.CustomerNotes, new HashSet<CustomerNote> { new CustomerNote(customer, new Note("Note Text", new User{Id = Guid.NewGuid(), UserName = "UserName2"}){Id=Guid.NewGuid()}) })
                .VerifyTheMappings(customer);
        }
    }
}