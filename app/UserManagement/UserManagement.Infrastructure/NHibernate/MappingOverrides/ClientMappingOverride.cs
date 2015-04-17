using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class ClientMappingOverride : IAutoMappingOverride<Client>
    {
        public void Override(AutoMapping<Client> mapping)
        {
            mapping.References(x => x.ClientAccountNumber).Cascade.Persist();
            mapping.References(x => x.ContactDetail).Cascade.SaveUpdate();
            mapping.HasMany(x => x.ClientUsers).Cascade.SaveUpdate();
            mapping.HasManyToMany(x => x.Contracts).Cascade.SaveUpdate().Table("ClientContract");
        }
    }
}