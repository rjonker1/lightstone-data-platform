using System;
using Billing.TestHelper.BaseTests;
using FluentNHibernate.Testing;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing
{
    public class when_persisting_prebilling_transaction : when_persisting_entities_to_db
    {
        [Observation]
        public void should_persist_customer()
        {
            new PersistenceSpecification<PreBilling>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.BillingId, 101)
                .CheckProperty(c => c.CustomerId, Guid.NewGuid())
                .CheckProperty(c => c.CustomerName, "Customer 1")
                .CheckProperty(c => c.PackageId, Guid.NewGuid())
                .CheckProperty(c => c.UserId, Guid.NewGuid())
                .CheckProperty(c => c.Username, "Username")
                .CheckProperty(c => c.TransactionId, Guid.NewGuid())
                .CheckProperty(c => c.DataProviderId, Guid.NewGuid())
                .CheckProperty(c => c.DataProviderName, "Package Test")
                .VerifyTheMappings();
        }
        
        [Observation]
        public void should_persist_client()
        {
            new PersistenceSpecification<PreBilling>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.BillingId, 102)
                .CheckProperty(c => c.ClientId, Guid.NewGuid())
                .CheckProperty(c => c.ClientName, "Client 1")
                .CheckProperty(c => c.UserId, Guid.NewGuid())
                .CheckProperty(c => c.Username, "Username")
                .CheckProperty(c => c.TransactionId, Guid.NewGuid())
                .CheckProperty(c => c.DataProviderId, Guid.NewGuid())
                .CheckProperty(c => c.DataProviderName, "Package Test")
                .VerifyTheMappings();
        }
    }
}