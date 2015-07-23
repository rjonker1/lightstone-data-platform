using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.MappingOverrides
{
    public class BillingMappingOverride : IAutoMappingOverride<BillingTransaction>
    {
        public void Override(AutoMapping<BillingTransaction> mapping)
        {
            mapping.DiscriminateSubClassesOnColumn("Type"); //, @"null").SqlType("VARCHAR").Not.Nullable().Length(128);
            mapping.Map(x => x.CustomerId).Index("CustomerId");
            mapping.Map(x => x.ClientId).Index("ClientId");
            mapping.Map(x => x.BillingType).Index("BillingType");
        }
    }
}