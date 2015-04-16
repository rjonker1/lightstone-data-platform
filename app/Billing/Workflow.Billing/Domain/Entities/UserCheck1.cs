using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class UserCheck1 : BillingTransaction
    {
        public virtual string Tester { get; set; }

        public UserCheck1()
        {
        }
    }
}