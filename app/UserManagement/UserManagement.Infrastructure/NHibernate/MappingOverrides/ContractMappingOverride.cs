using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class ContractMappingOverride : IAutoMappingOverride<Contract>
    {
        public void Override(AutoMapping<Contract> mapping)
        {
            mapping.HasManyToMany(x => x.Packages).Cascade.All().Table("ContractPackage");
        }
    }
}