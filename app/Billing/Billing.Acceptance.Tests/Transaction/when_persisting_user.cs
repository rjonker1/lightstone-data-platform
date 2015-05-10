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
            new PersistenceSpecification<UserMeta>(Session)
                .CheckProperty(c => c.Id, new Guid("6E801E69-6F5F-4D47-BE32-3DA0E96B0513"))
                .CheckProperty(c => c.Username, "Username")
                .CheckProperty(c => c.FirstName, "FirstName")
                .CheckProperty(c => c.LastName, "LastName")
                .CheckProperty(c => c.CreatedBy, "UNITTEST")
                .VerifyTheMappings();

        }
    }
}