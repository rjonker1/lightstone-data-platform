using EventTracking.Read.ReadModel.Models.DataProviders;
using FluentNHibernate.Mapping;

namespace EventTracking.Read.Persistence.Mappings
{
    public class DataProviderEventMap : ClassMap<EventForDataProviderModel>
    {
        public DataProviderEventMap()
        {
            Table("EventsFromDataProvider");
            Id(x => x.Id);
            Map(x => x.AggregateId);
            Map(x => x.Payload);
            Map(x => x.DataProviderId);
            Map(x => x.EventId);
            Map(x => x.IsJson);
            Map(x => x.MetaData);
            Map(x => x.Originator);
            Map(x => x.OrignalMessageId);
            Map(x => x.TimeStamp);
        }
    }
}
