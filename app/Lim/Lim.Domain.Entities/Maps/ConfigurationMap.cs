using FluentNHibernate.Mapping;
using Lim.Entities;

namespace Lim.Domain.Entities.Maps{
    public class ConfigurationMap : ClassMap<Configuration>{
        public ConfigurationMap()
        {
            Table("Configuration");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id").Index("IX_Configuration_Id");
            References(x => x.Client).Column("ClientId").Index("IX_Congfiguration_ClientId");
            References(x => x.FrequencyType).Column("FrequencyType").Index("IX_Congfiguration_FrequencyTypeId");
            References(x => x.ActionType).Column("ActionType").Index("IX_Congfiguration_ActionTypeId");
            References(x => x.IntegrationType).Column("IntegrationType").Index("IX_Congfiguration_IntegrationTypeId");
            Map(x => x.ConfigurationKey).Column("ConfigurationKey").Not.Nullable().Default("newid()").Generated.Insert();
            Map(x => x.DateCreated).Column("DateCreated").Not.Nullable().Default("GETUTCDATE()").Generated.Insert();
            Map(x => x.IsActive).Column("IsActive").Not.Nullable();
            Map(x => x.DateModified).Column("DateModified");
            Map(x => x.ModifiedBy).Column("ModifiedBy").Length(50);
            Map(x => x.CustomFrequencyTime).Column("CustomFrequencyTime").Nullable().CustomType("TimeAsTimeSpan");
            Map(x => x.CustomFrequencyDay).Column("CustomFrequencyDay").Nullable().Length(20);
        }
    }
}