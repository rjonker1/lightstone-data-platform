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
        }
    }
}