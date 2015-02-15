using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class ClientUserMappingOverride : IAutoMappingOverride<ClientUser>
    {
        public void Override(AutoMapping<ClientUser> mapping)
        {
            mapping.References(x => x.Client).Cascade.All();
            mapping.References(x => x.User).Cascade.All();
        }
    }
}