using System;
using Billing.TestHelper.BaseTests;
using FluentNHibernate.Testing;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction
{
    public class when_persisting_user : when_persisting_entities_to_db
    {
        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<User>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Username, "Username")
                .CheckProperty(c => c.FirstName, "FirstName")
                .CheckProperty(c => c.LastName, "LastName")
                .CheckProperty(c => c.Customer, "Customer1")
                .VerifyTheMappings();

            new PersistenceSpecification<UserCheck1>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Tester, "Test")
                .CheckProperty(c => c.Customer, "Customer 2")
                .VerifyTheMappings();
        }
    }
}