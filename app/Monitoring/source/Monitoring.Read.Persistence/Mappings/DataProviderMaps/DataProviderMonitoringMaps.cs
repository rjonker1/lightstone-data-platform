using FluentNHibernate.Mapping;
using Monitoring.Read.ReadModel.Models.DataProviders;

namespace Monitoring.Read.Persistence.Mappings.DataProviderMaps
{
    public class DataProviderMonitoringPerformanceMap : ClassMap<DataProviderMonitoringPerformanceModel>
    {
        public DataProviderMonitoringPerformanceMap()
        {
            Table("DataProviderMonitoringPerformance");
            Id(x => x.Id);
            Map(x => x.AggregateId);
            Map(x => x.Payload).Length(10000);
            Map(x => x.Message).Length(1000);
            Map(x => x.DataProviderId);
            Map(x => x.DataProvider).Length(50);
            Map(x => x.Category).Length(50);
            Map(x => x.CategoryId);
            Map(x => x.RequestAggregateId);
            Map(x => x.IsJson);
            Map(x => x.Metadata).Length(10000);
            Map(x => x.Date);
            Map(x => x.Originator);
            Map(x => x.OrignalMessageId);
            Map(x => x.TimeStamp);
        }
    }

    public class DataProviderMonitoringFaultMap : ClassMap<DataProviderMonitoringFaultModel>
    {
        public DataProviderMonitoringFaultMap()
        {
            Table("DataProviderMonitoringFault");
            Id(x => x.Id);
            Map(x => x.AggregateId);
            Map(x => x.Payload).Length(10000);
            Map(x => x.Message).Length(1000);
            Map(x => x.DataProviderId);
            Map(x => x.DataProvider).Length(50);
            Map(x => x.Category).Length(50);
            Map(x => x.CategoryId);
            Map(x => x.RequestAggregateId);
            Map(x => x.IsJson);
            Map(x => x.Metadata).Length(10000);
            Map(x => x.Date);
            Map(x => x.Originator);
            Map(x => x.OrignalMessageId);
            Map(x => x.TimeStamp);
        }
    }

    public class DataProviderMonitoringConfigurationMap : ClassMap<DataProviderMonitoringConfigurationModel>
    {
        public DataProviderMonitoringConfigurationMap()
        {
            Table("DataProviderMonitoringConfiguration");
            Id(x => x.Id);
            Map(x => x.AggregateId);
            Map(x => x.Payload).Length(10000);
            Map(x => x.Message).Length(1000);
            Map(x => x.DataProviderId);
            Map(x => x.DataProvider).Length(50);
            Map(x => x.Category).Length(50);
            Map(x => x.CategoryId);
            Map(x => x.RequestAggregateId);
            Map(x => x.IsJson);
            Map(x => x.Metadata).Length(10000);
            Map(x => x.Date);
            Map(x => x.Originator);
            Map(x => x.OrignalMessageId);
            Map(x => x.TimeStamp);
        }
    }

    public class DataProviderMonitoringSecurityMap : ClassMap<DataProviderMonitoringSecurityModel>
    {
        public DataProviderMonitoringSecurityMap()
        {
            Table("DataProviderMonitoringSecurity");
            Id(x => x.Id);
            Map(x => x.AggregateId);
            Map(x => x.Payload).Length(10000);
            Map(x => x.Message).Length(1000);
            Map(x => x.DataProviderId);
            Map(x => x.DataProvider).Length(50);
            Map(x => x.Category).Length(50);
            Map(x => x.CategoryId);
            Map(x => x.RequestAggregateId);
            Map(x => x.IsJson);
            Map(x => x.Metadata).Length(10000);
            Map(x => x.Date);
            Map(x => x.Originator);
            Map(x => x.OrignalMessageId);
            Map(x => x.TimeStamp);
        }
    }

    public class DataProviderMonitoringTransformationMap : ClassMap<DataProviderMonitoringTransformationModel>
    {
        public DataProviderMonitoringTransformationMap()
        {
            Table("DataProviderMonitoringTransformation");
            Id(x => x.Id);
            Map(x => x.AggregateId);
            Map(x => x.Payload).Length(10000);
            Map(x => x.Message).Length(1000);
            Map(x => x.DataProviderId);
            Map(x => x.DataProvider).Length(50);
            Map(x => x.Category).Length(50);
            Map(x => x.CategoryId);
            Map(x => x.RequestAggregateId);
            Map(x => x.IsJson);
            Map(x => x.Metadata).Length(10000);
            Map(x => x.Date);
            Map(x => x.Originator);
            Map(x => x.OrignalMessageId);
            Map(x => x.TimeStamp);
        }
    }
}
