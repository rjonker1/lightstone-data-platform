using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.MappingOverrides
{
    public class PreBillingMappingOverride : IAutoMappingOverride<PreBilling>
    {
        public void Override(AutoMapping<PreBilling> mapping)
        {
            mapping.HasManyToMany(x => x.Users).Cascade.SaveUpdate();
        }
    }
}