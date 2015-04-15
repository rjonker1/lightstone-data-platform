using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;

namespace Workflow.Billing.Helpers.AutoMapper.MappingOverrides
{
    public class BillingMappingOverride : IAutoMappingOverride<Domain.Entities.Billing>
    {
        public void Override(AutoMapping<Domain.Entities.Billing> mapping)
        {
            mapping.DiscriminateSubClassesOnColumn("Type"); //, @"null").SqlType("VARCHAR").Not.Nullable().Length(128);
        }
    }
}