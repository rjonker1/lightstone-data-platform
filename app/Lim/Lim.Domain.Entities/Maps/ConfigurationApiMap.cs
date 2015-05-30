using FluentNHibernate.Mapping;

namespace Lim.Domain.Entities.Maps {
    
    
    public class ConfigurationApiMap : ClassMap<ConfigurationApi> {
        
        public ConfigurationApiMap() {
			Table("ConfigurationApi");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("Id").Index("IX_ConfigurationApi_Id");
            References(x => x.Configuration).Column("ConfigurationId").Not.Nullable().Index("IX_ConfigurationApi_ConfigurationId");
            References(x => x.AuthenticationType).Column("AuthenticationType").Index("IX_ConfigurationApi_AuthenticationTypeId");
            Map(x => x.BaseAddress).Column("BaseAddress").Not.Nullable().Length(1000); ;
			Map(x => x.Suffix).Column("Suffix").Not.Nullable();
            Map(x => x.Username).Column("Username").Length(50); ;
            Map(x => x.Password).Column("Password").Length(100); ;
			Map(x => x.HasAuthentication).Column("HasAuthentication").Not.Nullable();
            Map(x => x.AuthenticationToken).Column("AuthenticationToken").Length(500); ;
            Map(x => x.AuthenticationKey).Column("AuthenticationKey").Length(50); ;
			//Map(x => x.AuthenticationType).Column("AuthenticationType").Not.Nullable();
            Map(x => x.DateCreated).Column("DateCreated").Not.Nullable().Default("GETUTCDATE()").Not.Nullable().Generated.Insert();
        }
    }
}
