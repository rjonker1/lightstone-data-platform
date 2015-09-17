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
            RefreshDb(false);
        }

        [Observation]
        public void should_persist()
        {
            var physicalAddress = new Address("Line1", "Line2", "PostalCode", "City", new Country("South Africa"), "PostalCode", new Province("Gauteng"));
            var postalAddress = new Address("Line1", "Line2", "PostalCode", "City", new Country("Botswana"), "PostalCode", new Province("KZN"));
            var client = new Client("Client");
            new PersistenceSpecification<Client>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Name, "Client")
                .CheckList(c => c.Contracts, new HashSet<Contract> { new Contract(DateTime.UtcNow, "Name", "Detail", "By", DateTime.UtcNow, "RegisteredName", "Reg#", new ContractType("Type"), EscalationType.AnnualPercentageAllProducts, ContractDuration.Custom) })
                .CheckList(c => c.UserAliases, new HashSet<ClientUserAlias> { new ClientUserAlias() })
                .CheckList(c => c.Industries, new List<ClientIndustry> { new ClientIndustry(client, Guid.NewGuid()) })
                .CheckList(c => c.Addresses, new HashSet<ClientAddress> { new ClientAddress(client, physicalAddress, AddressType.Physical), new ClientAddress(client, postalAddress, AddressType.Postal) })
                .VerifyTheMappings(client);
        }
    }
}