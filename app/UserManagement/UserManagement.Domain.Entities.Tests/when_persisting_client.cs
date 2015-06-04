using System;
using System.Collections.Generic;
using FluentNHibernate.Testing;
using UserManagement.Domain.Enums;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Domain.Entities.Tests
{
    public class when_persisting_client : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist()
        {
            var physicalAddress = new Address(AddressType.Physical, "Line1", "Line2", "PostalCode", "City", "Country", "PostalCode", new Province("Gauteng"));
            var postalAddress = new Address(AddressType.Postal, "Line1", "Line2", "PostalCode", "City", "Country", "PostalCode", new Province("KZN"));
            var id = Guid.NewGuid();
            var client = new Client("Client");
            new PersistenceSpecification<Client>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, id)
                .CheckProperty(c => c.Name, "Client")
                .CheckReference(c => c.ContactDetail, new ContactDetail("Name", "Number", "EmailAddress", physicalAddress, postalAddress))
                .CheckComponentList(c => c.Contracts, new HashSet<Contract> { new Contract(DateTime.Now, "Name", "Detail", "By", DateTime.Now, "RegisteredName", "Reg#", new ContractType("Type"), new EscalationType("Esc"), new ContractDuration("Dur")) })
                .CheckComponentList(c => c.ClientUsers, new HashSet<ClientUser> { new ClientUser(client, "Alias") })
                //.CheckProperty(c => c.Industries, new[] { Guid.NewGuid(), Guid.NewGuid() })
                .CheckComponentList(c => c.Industries, new List<ClientIndustry> { new ClientIndustry { Client = client, IndustryId = Guid.NewGuid() } })
                .VerifyTheMappings(client);
        }
    }
}