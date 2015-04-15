using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Billing.TestHelper.BaseTests;
using FluentNHibernate.Testing;
using NHibernate.Mapping;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction
{
    public class when_persisting_transaction_with_products : when_persisting_entities_to_db
    {

        [Observation]
        public void should_persist()
        {
            new PersistenceSpecification<MockTransaction>(Session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.CustomerId, Guid.NewGuid())
                .CheckProperty(c => c.CustomerName, "Customer")
                .CheckProperty(c => c.TransactionId, Guid.NewGuid())
                .CheckProperty(c => c.ProductId, Guid.NewGuid())
                .CheckProperty(c => c.ProductName, "Test Product")
                .VerifyTheMappings();
                    
        }
    }
}