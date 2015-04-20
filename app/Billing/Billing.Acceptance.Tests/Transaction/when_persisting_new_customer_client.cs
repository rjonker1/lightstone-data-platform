using System;
using Billing.TestHelper.BaseTests;
using FluentNHibernate.Testing;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction
{
    public class when_persisting_new_customer_client : when_persisting_entities_to_db
    {
        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<Customer>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.AccountNumber, "CUS001")
                .CheckProperty(c => c.CustomerId, Guid.NewGuid())
                .CheckProperty(c => c.CustomerName, "Customer 1")
                .VerifyTheMappings();

            new PersistenceSpecification<Client>(Session)
               .CheckProperty(c => c.Id, Guid.NewGuid())
               .CheckProperty(c => c.AccountNumber, "CLIENT001")
               .CheckProperty(c => c.ClientId, Guid.NewGuid())
               .CheckProperty(c => c.ClientName, "Client 1")
               .VerifyTheMappings();
        }
    }
}