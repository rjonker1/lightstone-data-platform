using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class ClientMappingOverride : IAutoMappingOverride<Client>
    {
        public void Override(AutoMapping<Client> mapping)
        {
            mapping.References(x => x.ContactDetail).Cascade.All();
            mapping.HasMany(x => x.ClientUsers).Cascade.All();
            mapping.HasManyToMany(x => x.Packages).Cascade.All().Table("ClientPackage").ParentKeyColumn("ClientId").ChildKeyColumn("PackageId");
        }
    }
}