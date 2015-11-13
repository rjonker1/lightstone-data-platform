using FluentNHibernate.Mapping;

namespace Lim.Domain.Entities.Maps
{
    public class IntegrationTrackingMap : ClassMap<IntegrationTracking>
    {
        public IntegrationTrackingMap()
        {
            Table("IntegrationTracking");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id").Index("IX_IntegrationTracking_Id");
            References(x => x.Configuration).Column("ConfigurationId").Index("IX_IntegrationTracking_ConfigurationId");
            Map(m => m.TransactionCount).Column("TransactionCount").Nullable().Default("0");
            Map(m => m.MaxTransactionDate).Column("MaxTransactionDate").Not.Nullable();
            Map(m => m.Updated).Column("Updated").Not.Nullable().Default("GETUTCDATE()");
        }
    }
}