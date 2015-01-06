using FluentNHibernate.Mapping;
using Monitoring.Read.ReadModel.Models;

namespace Monitoring.Read.Persistence.Mappings
{
    public class MonitoringMap : ClassMap<MonitoringStorageModel>
    {
        public MonitoringMap()
        {
            Table("Monitoring");
            Id(x => x.Id);
            Map(x => x.AggregateId);
            Map(x => x.Payload).Length(2147483647);
            Map(x => x.Source).Length(20);
            Map(x => x.Date);
            Map(x => x.TimeStamp);
        }
    }
}
