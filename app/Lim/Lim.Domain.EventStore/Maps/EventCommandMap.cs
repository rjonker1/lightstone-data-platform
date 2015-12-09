using FluentNHibernate.Mapping;
using Lim.Domain.EventStore.Entities;

namespace Lim.Domain.EventStore.Maps
{
    public class EventCommandMap : ClassMap<EventCommand>
    {
        public EventCommandMap()
        {
            Table("Events");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(m => m.AggregateId).Column("AggregateId").Not.Nullable().Index("IX_Events_AggregateId");
            Map(m => m.EventType).Column("EventType").Nullable().Length(100);
            Map(m => m.EventTypeId).Column("EventTypeId").Nullable().Index("IX_Events_EventTypeId");
            Map(m => m.Payload).Column("Payload").Not.Nullable().Length(int.MaxValue);
            Map(m => m.Version).Column("Version").Not.Nullable();
            Map(m => m.UserId).Column("UserId").Not.Nullable().Index("IX_Events_User");
            Map(m => m.CorrelationId).Column("CorrelationId").Not.Nullable().Index("IX_Events_CorrelationId");
            Map(m => m.AggregateNew).Column("AggregateNew").Not.Nullable().Default("0");
            Map(m => m.CommitStamp).Column("CommitStamp").Not.Nullable().Default("GETUTCDATE()").Generated.Insert();
            Map(m => m.Type).Column("Type").Not.Nullable().Length(2000);
            Map(m => m.TypeName).Column("TypeName").Not.Nullable().Length(500);
        }
    }
}
