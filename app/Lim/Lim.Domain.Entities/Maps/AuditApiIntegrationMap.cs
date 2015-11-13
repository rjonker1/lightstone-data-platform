using FluentNHibernate.Mapping;

namespace Lim.Domain.Entities.Maps {
    public class AuditApiIntegrationMap : ClassMap<AuditApiIntegration> {
        
        public AuditApiIntegrationMap() {
			Table("AuditApiIntegration");
            Not.LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("Id");
			Map(x => x.ClientId).Column("ClientId").Not.Nullable().Index("IX_Audit_ClientId");
            Map(x => x.ConfigurationId).Column("ConfigurationId").Not.Nullable().Index("IX_Audit_ConfigurationId"); ;
			Map(x => x.ActionType).Column("ActionType").Not.Nullable();
            Map(x => x.IntegrationType).Column("IntegrationType").Not.Nullable().Index("IX_Audit_IntegrationType");
            Map(x => x.Date).Column("Date").Default("GETUTCDATE()").Not.Nullable().Generated.Insert();
			Map(x => x.WasSuccessful).Column("WasSuccessful").Not.Nullable();
			Map(x => x.Address).Column("Address").Not.Nullable();
			Map(x => x.Suffix).Column("Suffix").Not.Nullable();
            Map(x => x.Payload).Column("Payload").Not.Nullable().Length(10000);
        }
    }
}
