﻿using System;
using Billing.TestHelper.BaseTests;
using FluentNHibernate.Testing;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction.Billing
{
    public class when_persisting_transaction_archive : when_persisting_entities_to_db
    {
        [Observation]
        public void should_persist_customer()
        {
            new PersistenceSpecification<ArchiveBillingTransaction>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.CustomerId, Guid.NewGuid())
                .CheckProperty(c => c.CustomerName, "Customer 1")
                .CheckProperty(c => c.Package.PackageId, Guid.NewGuid())
                .CheckProperty(c => c.User.UserId, Guid.NewGuid())
                .CheckProperty(c => c.User.Username, "Username")
                .CheckProperty(c => c.UserTransaction.TransactionId, Guid.NewGuid())
                .CheckProperty(c => c.DataProvider.DataProviderId, Guid.NewGuid())
                .CheckProperty(c => c.DataProvider.DataProviderName, "Package Test")
                .VerifyTheMappings();
        }

        [Observation]
        public void should_persist_client()
        {
            new PersistenceSpecification<ArchiveBillingTransaction>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.ClientId, Guid.NewGuid())
                .CheckProperty(c => c.ClientName, "Client 1")
                .CheckProperty(c => c.Package.PackageId, Guid.NewGuid())
                .CheckProperty(c => c.User.UserId, Guid.NewGuid())
                .CheckProperty(c => c.User.Username, "Username")
                .CheckProperty(c => c.UserTransaction.TransactionId, Guid.NewGuid())
                .CheckProperty(c => c.DataProvider.DataProviderId, Guid.NewGuid())
                .CheckProperty(c => c.DataProvider.DataProviderName, "Package Test")
                .VerifyTheMappings();
        }
    }
}