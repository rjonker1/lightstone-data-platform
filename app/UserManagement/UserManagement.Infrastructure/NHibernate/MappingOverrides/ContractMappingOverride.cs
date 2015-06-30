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
            mapping.HasManyToMany(x => x.Packages).Cascade.SaveUpdate().Table("ContractPackage").ParentKeyColumn("ContractId").ChildKeyColumn("PackageId"); ;
            mapping.HasManyToMany(x => x.Customers).Cascade.SaveUpdate().Table("CustomerContract").ParentKeyColumn("ContractId").ChildKeyColumn("CustomerId"); ;
            mapping.HasManyToMany(x => x.Clients).Cascade.SaveUpdate().Table("ClientContract").ParentKeyColumn("ContractId").ChildKeyColumn("ClientId");
        }
    }
}