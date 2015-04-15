using System;
using System.Data.SqlTypes;
using System.Globalization;
using Billing.TestHelper.BaseTests;
using FluentNHibernate.Testing;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction
{
    public class when_persisting_product : when_persisting_entities_to_db
    {

        //[Observation]
        //public void should_persist()
        //{
        //    new PersistenceSpecification<MockProduct>(Session)
        //        .CheckProperty(c => c.TransactionDate, DateTime.UtcNow.Date)
        //        .CheckProperty(c => c.ProductName, "Test Product 1")
        //        .VerifyTheMappings();
        //}
    }
}