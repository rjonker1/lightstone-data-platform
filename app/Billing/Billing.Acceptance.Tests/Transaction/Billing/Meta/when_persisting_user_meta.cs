using System;
using Billing.TestHelper.BaseTests;
using FluentNHibernate.Testing;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing.Meta
{
    public class when_persisting_user_meta : when_persisting_entities_to_db
    {
        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<UserMeta>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.Username, "testeroonie123")
                .CheckProperty(c => c.FirstName, "Test")
                .CheckProperty(c => c.LastName, "Roonie")
                .VerifyTheMappings();

        }
    }
}