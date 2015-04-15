using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Workflow.Billing.Helpers.AutoMapper.MappingOverrides
{
    public class BillingMappingOverride : IAutoMappingOverride<Domain.Entities.Billing>
    {
        public void Override(AutoMapping<Domain.Entities.Billing> mapping)
        {
            mapping.DiscriminateSubClassesOnColumn("UserType");
        }
    }
}