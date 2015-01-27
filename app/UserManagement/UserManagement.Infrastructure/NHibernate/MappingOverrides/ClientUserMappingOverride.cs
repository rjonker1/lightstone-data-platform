using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Conventions.Helpers;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class ClientUserMappingOverride : IAutoMappingOverride<ClientUser>
    {
        public void Override(AutoMapping<ClientUser> mapping)
        {
            mapping.Table("ClientUser");
            mapping.CompositeId().KeyReference(x => x.Client, "ClientId")
                                 .KeyReference(x => x.User, "UserId");

            mapping.Map(x => x.UserAlias);

        }
    }
}