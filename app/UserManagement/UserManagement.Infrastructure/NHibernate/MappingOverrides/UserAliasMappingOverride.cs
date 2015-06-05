using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class UserAliasMappingOverride : IAutoMappingOverride<UserAlias>
    {
        public void Override(AutoMapping<UserAlias> mapping)
        {
            mapping.HasManyToMany(x => x.Users).Cascade.SaveUpdate();
        }
    }
}