using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class ClientIndustryOverride : IAutoMappingOverride<ClientIndustry>
    {
        public void Override(AutoMapping<ClientIndustry> mapping)
        {
            mapping.References(x => x.Client).Cascade.SaveUpdate();
        }
    }
}