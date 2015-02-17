using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class ContractMappingOverride : IAutoMappingOverride<Contract>
    {
        public void Override(AutoMapping<Contract> mapping)
        {
            mapping.References(x => x.ContractType).Cascade.All();
            mapping.References(x => x.EscalationType).Cascade.All();
            mapping.References(x => x.ContractDuration).Cascade.All();
            mapping.HasManyToMany(x => x.Packages).Cascade.All().Table("ContractPackage");
            mapping.HasManyToMany(x => x.Customers).Cascade.All().Table("CustomerContract");
            mapping.HasManyToMany(x => x.Clients).Cascade.All().Table("ClientContract");
        }
    }
}