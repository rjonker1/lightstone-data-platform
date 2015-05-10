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
                .CheckProperty(c => c.Id, "A729F8E4-5677-4C0B-98E5-BDC7E902FDB4")
                .CheckProperty(c => c.Username, "Username")
                .CheckProperty(c => c.FirstName, "FirstName")
                .CheckProperty(c => c.LastName, "LastName")
                .CheckProperty(c => c.CreatedBy, "UNITTEST")
                .VerifyTheMappings();

        }
    }
}