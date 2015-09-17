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
    public class when_persisting_contract : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb();
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<Contract>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.CommencementDate, DateTime.UtcNow.Date)
                .CheckProperty(c => c.Name, "Name")
                .CheckProperty(c => c.Description, "Description")
                .CheckProperty(c => c.EnteredIntoBy, "EnteredIntoBy")
                .CheckProperty(c => c.OnlineAcceptance, DateTime.UtcNow.Date)
                .CheckProperty(c => c.RegisteredName, "RegisteredName")
                .CheckProperty(c => c.RegistrationNumber, "RegistrationNumber")
                .CheckReference(c => c.ContractType, new ContractType("ContractType"))
                .CheckProperty(c => c.EscalationType, EscalationType.AnnualPercentageAllProducts)
                .CheckProperty(c => c.ContractDuration, ContractDuration.Custom)
                .CheckComponentList(c => c.Clients, new HashSet<Client> { new Client("Name") })
                .CheckComponentList(c => c.Customers, new HashSet<Customer> { new Customer("Name") })
                .CheckComponentList(c => c.Packages, new HashSet<Package> { new Package("Name", Guid.NewGuid()) })
                .VerifyTheMappings();
        }
    }
}