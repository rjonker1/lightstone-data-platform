using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Workflow.Billing.Domain.Entities
{
    public class MockProduct : BillingTransaction
    {
        public virtual Guid ProductId { get; set; }
        public virtual string ProductName { get; set; }
    }
}