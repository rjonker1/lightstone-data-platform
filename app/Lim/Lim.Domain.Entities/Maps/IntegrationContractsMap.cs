using FluentNHibernate.Mapping;
using Lim.Entities;

namespace Lim.Domain.Entities.Maps {
    
    
    public class IntegrationContractsMap : ClassMap<IntegrationContract> {
        
        public IntegrationContractsMap() {
			Table("IntegrationContracts");
            Not.LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("Id").Index("IX_IntegrationContract_Id");
            References(x => x.Configuration).Column("ConfigurationId").Index("IX_IntegrationContract_ConfigurationId"); ;
			Map(x => x.Contract).Column("Contract").Not.Nullable();
            Map(x => x.ClientCustomerId).Column("ClientCustomerId").Not.Nullable().Index("IX_IntegrationContract_ClientId"); ;
            Map(x => x.DateCreated).Column("DateCreated").Default("GETUTCDATE()").Not.Nullable().Generated.Insert();
			Map(x => x.IsActive).Column("IsActive").Not.Nullable();
			Map(x => x.DateModified).Column("DateModified");
            Map(x => x.ModifiedBy).Column("ModifiedBy").Length(50); ;
        }
    }
}
