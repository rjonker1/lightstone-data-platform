using FluentNHibernate.Mapping;

namespace Lim.Domain.Entities.Maps {
    
    
    public class IntegrationClientsMap : ClassMap<IntegrationClients> {
        
        public IntegrationClientsMap() {
			Table("IntegrationClients");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("Id").Index("IX_IntegrationClient_Id");
            References(x => x.Configuration).Column("ConfigurationId").Index("IX_IntegrationClient_ConfigurationId"); ;
            Map(x => x.ClientCustomerId).Column("ClientCustomerId").Not.Nullable().Index("IX_IntegrationClient_ClientId");
			Map(x => x.AccountNumber).Column("AccountNumber").Not.Nullable();
            Map(x => x.DateCreated).Column("DateCreated").Default("GETUTCDATE()").Not.Nullable().Generated.Insert();
			Map(x => x.IsActive).Column("IsActive").Not.Nullable();
			Map(x => x.DateModified).Column("DateModified");
            Map(x => x.ModifiedBy).Column("ModifiedBy").Length(50); ;
        }
    }
}
