﻿using System;
using Billing.TestHelper.BaseTests;
using FluentNHibernate.Testing;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction
{
    public class when_persisting_billing_transaction : when_persisting_entities_to_db
    {
        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<MockPreBilling>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.BillingId, 101)
                .CheckProperty(c => c.CustomerId, Guid.NewGuid())
                .CheckProperty(c => c.CustomerName, "CustomerName")
                .CheckProperty(c => c.UserId, Guid.NewGuid())
                .CheckProperty(c => c.Username, "Username")
                .VerifyTheMappings();

            new PersistenceSpecification<MockPreBilling>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.BillingId, 102)
                .CheckProperty(c => c.ClientId, Guid.NewGuid())
                .CheckProperty(c => c.ClientName, "ClientName")
                .CheckProperty(c => c.UserId, Guid.NewGuid())
                .CheckProperty(c => c.Username, "Username")
                .VerifyTheMappings();
        }
    }
}