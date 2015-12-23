using FluentNHibernate.Mapping;
using Lim.Entities;

namespace Lim.Domain.Entities.Maps {
    
    
    public class IntegrationPackagesMap : ClassMap<IntegrationPackage> {
        
        public IntegrationPackagesMap() {
			Table("IntegrationPackages");
            Not.LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("Id").Index("IX_IntegrationPackages_Id");
            References(x => x.Configuration).Column("ConfigurationId").Index("IX_IntegrationPackages_ConfigurationId"); ;
            Map(x => x.PackageId).Column("PackageId").Not.Nullable().Index("IX_IntegrationPackages_PackageId"); ;
            Map(x => x.ContractId).Column("ContractId").Not.Nullable().Index("IX_IntegrationPackages_ContractId"); ;
            Map(x => x.DateCreated).Column("DateCreated").Default("GETUTCDATE()").Not.Nullable().Generated.Insert();
			Map(x => x.IsActive).Column("IsActive").Not.Nullable();
			Map(x => x.DateModified).Column("DateModified");
            Map(x => x.ModifiedBy).Column("ModifiedBy").Length(50);
        }
    }
}
