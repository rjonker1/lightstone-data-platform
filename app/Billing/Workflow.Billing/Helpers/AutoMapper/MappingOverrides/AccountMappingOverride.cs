using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.MappingOverrides
{
    public class AccountMappingOverride : IAutoMappingOverride<AccountMeta>
    {
        public void Override(AutoMapping<AccountMeta> mapping)
        {
            mapping.DiscriminateSubClassesOnColumn("Type");
        }
    }
}