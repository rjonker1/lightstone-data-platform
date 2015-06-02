using FluentNHibernate.Mapping;

namespace Lim.Domain.Entities.Maps
{
    public class IntegrationTrackingMap : ClassMap<IntegrationTracking>
    {
        public IntegrationTrackingMap()
        {
            Table("IntegrationTracking");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id").Index("IX_IntegrationTracking_Id");
            References(x => x.Action).Column("ActionId").Index("IX_IntegrationTracking_ActionId");
            References(x => x.Frequency).Column("FrequencyId").Index("IX_IntegrationTracking_FrequencyId");
            References(x => x.Type).Column("TypeId").Index("IX_IntegrationTracking_TypeId");
            Map(m => m.TransactionCount).Column("TransactionCount").Nullable().Default("0");
            Map(m => m.MaxTransactionDate).Column("MaxTransactionDate").Not.Nullable();
            Map(m => m.Updated).Column("Updated").Not.Nullable().Default("GETUTCDATE()");
        }
    }
}