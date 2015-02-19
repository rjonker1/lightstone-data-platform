using System;
using System.Collections.Generic;
using FluentNHibernate.Testing;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Domain.Entities.Tests
{
    public class when_persisting_contract : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<Contract>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.CommencementDate, DateTime.Now.Date)
                .CheckProperty(c => c.Description, "Description")
                .CheckProperty(c => c.EnteredIntoBy, "EnteredIntoBy")
                .CheckProperty(c => c.OnlineAcceptance, DateTime.Now.Date)
                .CheckProperty(c => c.RegisteredName, "RegisteredName")
                .CheckProperty(c => c.RegistrationNumber, "RegistrationNumber")
                .CheckReference(c => c.ContractType, new ContractType("ContractType"))
                .CheckReference(c => c.EscalationType, new EscalationType("EscalationType"))
                .CheckReference(c => c.ContractDuration, new ContractDuration("ContractDuration"))
                .CheckComponentList(c => c.Clients, new HashSet<Client> { new Client() })
                .CheckComponentList(c => c.Customers, new HashSet<Customer> { new Customer() })
                .CheckComponentList(c => c.Packages, new HashSet<Package> { new Package("Name", Guid.NewGuid()) })
                .VerifyTheMappings();
        }
    }
}