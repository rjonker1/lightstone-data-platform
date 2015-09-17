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
    public class when_persisting_client : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb();
        }

        [Observation]
        public void should_persist()
        {
            var physicalAddress = new Address("Line1", "Line2", "PostalCode", "City", new Country("South Africa"), "PostalCode", new Province("Gauteng"));
            var postalAddress = new Address("Line1", "Line2", "PostalCode", "City", new Country("Botswana"), "PostalCode", new Province("KZN"));
            var id = Guid.NewGuid();
            var client = new Client("Client");
            new PersistenceSpecification<Client>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, id)
                .CheckProperty(c => c.Name, "Client")
                .CheckReference(c => c.ContactDetail, new ContactDetail("Name", "Number", "EmailAddress", physicalAddress, postalAddress))
                .CheckComponentList(c => c.Contracts, new HashSet<Contract> { new Contract(DateTime.UtcNow, "Name", "Detail", "By", DateTime.UtcNow, "RegisteredName", "Reg#", new ContractType("Type"), EscalationType.AnnualPercentageAllProducts, ContractDuration.Custom) })
                .CheckComponentList(c => c.UserAliases, new HashSet<ClientUserAlias> { new ClientUserAlias() })
                //.CheckProperty(c => c.Industries, new[] { Guid.NewGuid(), Guid.NewGuid() })
                .CheckComponentList(c => c.Industries, new List<ClientIndustry> { new ClientIndustry (client, Guid.NewGuid())})
                .VerifyTheMappings(client);
        }
    }
}