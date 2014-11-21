using FluentNHibernate.Mapping;
using Monitoring.Read.ReadModel.Models.DataProviders;

namespace Monitoring.Read.Persistence.Mappings.DataProviderMaps
{
    public class DataProviderMonitoringMap : ClassMap<DataProviderMonitoringModel>
    {
        public DataProviderMonitoringMap()
        {
            Table("DataProviderMonitoring");
            Id(x => x.Id);
            Map(x => x.AggregateId);
            Map(x => x.Payload);
            Map(x => x.DataProviderId);
            Map(x => x.DataProvider);
            Map(x => x.Category);
            Map(x => x.CategoryId);
            Map(x => x.RequestAggregateId);
            Map(x => x.IsJson);
            Map(x => x.Metadata);
            Map(x => x.Date);
            Map(x => x.Originator);
            Map(x => x.OrignalMessageId);
            Map(x => x.TimeStamp);
        }
    }
}
