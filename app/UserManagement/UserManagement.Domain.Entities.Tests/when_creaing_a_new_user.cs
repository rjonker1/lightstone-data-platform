using System;
using System.Collections.Generic;
using FluentNHibernate.Testing;
using NHibernate;
using UserManagement.TestHelper.BaseTests;
using Xunit.Extensions;

namespace UserManagement.Domain.Entities.Tests
{
    public class when_creaing_a_new_user : when_persisting_entities_to_db
    {
        private ISession _session;
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_add_user_and_relational_references()
        {
            new PersistenceSpecification<User>(_session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.UserName, "test")
                .CheckProperty(c => c.Password, "test")
                .CheckProperty(c => c.ModifiedBy, "test")
                .CheckProperty(c => c.IsActive, true)
                .CheckProperty(c => c.Created, DateTime.Now.Date)
                .CheckProperty(c => c.Modified, DateTime.Now.Date)
                .CheckReference(c => c.UserType, new UserType(Guid.NewGuid(), "Test"))
                .CheckComponentList(c => c.Roles, new List<Role> { new Role(new Guid("c628ba87-bab5-44a1-98f8-16ec5c560f85"), "Admin") })
                .VerifyTheMappings();
        }
    }
}
