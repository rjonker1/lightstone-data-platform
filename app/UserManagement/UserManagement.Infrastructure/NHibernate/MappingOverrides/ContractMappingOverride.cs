using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class ContractMappingOverride : IAutoMappingOverride<Contract>
    {
        public void Override(AutoMapping<Contract> mapping)
        {
            mapping.References(x => x.ContractType).Cascade.SaveUpdate();
            mapping.References(x => x.EscalationType).Cascade.SaveUpdate();
            mapping.References(x => x.ContractDuration).Cascade.SaveUpdate();
            mapping.HasManyToMany(x => x.Packages).Cascade.SaveUpdate().Table("ContractPackage");
            mapping.HasManyToMany(x => x.Customers).Cascade.SaveUpdate().Table("CustomerContract");
            mapping.HasManyToMany(x => x.Clients).Cascade.SaveUpdate().Table("ClientContract");
        }
    }
}