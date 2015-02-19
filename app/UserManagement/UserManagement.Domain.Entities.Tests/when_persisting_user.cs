using System;
using System.Collections.Generic;
using FluentNHibernate.Testing;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit.Extensions;

namespace UserManagement.Domain.Entities.Tests
{
    public class when_persisting_user : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist()
        {
            var user = new User();
            var roles = new HashSet<Role> { new Role("Admin") };
            //var user1 = new User("Name", "Surname", "IdNumber", "Number", "UserName", "Password", true, new UserType("Type"), roles);
            new PersistenceSpecification<User>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.FirstName, "FirstName")
                .CheckProperty(c => c.LastName, "LastName")
                .CheckProperty(c => c.IdNumber, "IdNumber")
                .CheckProperty(c => c.ContactNumber, "ContactNumber")
                .CheckProperty(c => c.UserName, "UserName")
                .CheckProperty(c => c.Password, "Password")
                .CheckProperty(c => c.IsActive, true)
                .CheckReference(c => c.UserType, new UserType("Test"))
                .CheckComponentList(c => c.Roles, roles)
                .CheckComponentList(c => c.Customers, new HashSet<Customer> { new Customer("Name", "AccName", new CommercialState("State"), new CreateSource("Source"), new PlatformStatus("Status"), null) })
                .CheckComponentList(c => c.ClientUsers, new HashSet<ClientUser> { new ClientUser(new Client("Client"), "Alias") })
                .VerifyTheMappings(user);
        }
    }
}
