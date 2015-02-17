using System;
using System.Collections.Generic;
using FluentNHibernate.Testing;
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
            var physicalAddress = new Address("Type", "Line1", "Line2", "PostalCode", "City", "Country", "PostalCode", new Province("Gauteng"));
            var postalAddress = new Address("Type", "Line1", "Line2", "PostalCode", "City", "Country", "PostalCode", new Province("Gauteng"));
            var id = Guid.NewGuid();
            var client = new Client("Client");
            var roles = new HashSet<Role>{new Role("Role")};
            var userType = new UserType("UserType");
            var user = new User("FirstName", "LastName", "IdNumber", "ContactNumber", "UserName", "Password", false, userType, roles);
            new PersistenceSpecification<Client>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, id)
                .CheckProperty(c => c.Name, "Client")
                .CheckReference(c => c.ContactDetail, new ContactDetail("Name", "ContactName", "EmailAddess", "Tel", physicalAddress, postalAddress))
                .CheckComponentList(c => c.Contracts, new HashSet<Contract> { new Contract(DateTime.Now, "Name", "Detail", "By", DateTime.Now, "RegisteredName", "Reg#", new ContractType("Type"), new EscalationType("Esc"), new ContractDuration("Dur")) })
                .CheckComponentList(c => c.ClientUsers, new HashSet<ClientUser> { new ClientUser(client, user, "Alias") })
                .VerifyTheMappings(client);
        }
    }
}