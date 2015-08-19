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
    public class when_persisting_user : TestDataBaseHelper
    {
        public override void Observe()
        {
            RefreshDb(false);
        }

        [Observation]
        public void should_persist()
        {
            var roles = new HashSet<Role> { new Role("Admin") };
            new PersistenceSpecification<User>(Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.FirstName, "FirstName")
                .CheckProperty(c => c.LastName, "LastName")
                .CheckProperty(c => c.IdNumber, "IdNumber")
                .CheckProperty(c => c.ContactNumber, "ContactNumber")
                .CheckProperty(c => c.UserName, "UserName")
                .CheckProperty(c => c.Password, "Password")
                .CheckProperty(c => c.IsActive, true)
                .CheckProperty(c => c.UserType, UserType.Internal)
                .CheckComponentList(c => c.Roles, roles)
                .CheckComponentList(c => c.CustomerUsers, new HashSet<CustomerUser> { new CustomerUser(new Customer("Name"), new User(), true) })
                //.CheckComponentList(c => c.Clients, new HashSet<Client> { new Client("Client") })
                .VerifyTheMappings();
        }
    }
}
