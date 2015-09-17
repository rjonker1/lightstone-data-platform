using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class CustomerIndustryOverride : IAutoMappingOverride<CustomerIndustry>
    {
        public void Override(AutoMapping<CustomerIndustry> mapping)
        {
            mapping.References(x => x.Customer).Cascade.SaveUpdate();
        }
    }
}