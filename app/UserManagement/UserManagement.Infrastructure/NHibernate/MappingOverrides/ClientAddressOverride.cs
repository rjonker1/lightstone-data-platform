using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class ClientAddressOverride : IAutoMappingOverride<ClientAddress>
    {
        public void Override(AutoMapping<ClientAddress> mapping)
        {
            mapping.References(x => x.Client).Cascade.SaveUpdate();
            mapping.References(x => x.Address).Cascade.SaveUpdate();
        }
    }
}