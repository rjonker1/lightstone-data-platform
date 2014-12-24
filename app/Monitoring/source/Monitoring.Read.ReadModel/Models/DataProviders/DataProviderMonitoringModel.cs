using System;
namespace Monitoring.Read.ReadModel.Models.DataProviders
{
    public class MonitoringDataProviderModel : ReadModelEntity
    {
        public MonitoringDataProviderModel()
        {
        }

        public MonitoringDataProviderModel(Guid id)
            : base(id)
        {

        }

        public virtual string Originator { get; set; }
        public virtual string OrignalMessageId { get; set; }
        public virtual Guid RequestAggregateId { get; set; }
        public virtual string Payload { get; set; }
        public virtual string Message { get; set; }
        public virtual int DataProviderId { get; set; }
        public virtual string DataProvider { get; set; }
        public virtual string Category { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual bool IsJson { get; set; }
        public virtual string Metadata { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }

    //public class DataProviderMonitoringPerformanceModel : ReadModelEntity
    //{
    //    public DataProviderMonitoringPerformanceModel()
    //    {
    //    }

    //    public DataProviderMonitoringPerformanceModel(Guid id) : base(id)
    //    {
            
    //    }

    //    public virtual string Originator { get; set; }
    //    public virtual string OrignalMessageId { get; set; }
    //    public virtual Guid RequestAggregateId { get; set; }
    //    public virtual string Payload { get; set; }
    //    public virtual string Message { get; set; }
    //    public virtual int DataProviderId { get; set; }
    //    public virtual string DataProvider { get; set; }
    //    public virtual string Category { get; set; }
    //    public virtual int CategoryId { get; set; }
    //    public virtual bool IsJson { get; set; }
    //    public virtual string Metadata { get; set; }
    //    public virtual DateTime Date { get; set; }
    //    public virtual DateTime TimeStamp { get; set; }
    //}

    //public class DataProviderMonitoringFaultModel : ReadModelEntity
    //{
    //    public DataProviderMonitoringFaultModel()
    //    {
    //    }

    //    public DataProviderMonitoringFaultModel(Guid id)
    //        : base(id)
    //    {

    //    }

    //    public virtual string Originator { get; set; }
    //    public virtual string OrignalMessageId { get; set; }
    //    public virtual Guid RequestAggregateId { get; set; }
    //    public virtual string Payload { get; set; }
    //    public virtual string Message { get; set; }
    //    public virtual int DataProviderId { get; set; }
    //    public virtual string DataProvider { get; set; }
    //    public virtual string Category { get; set; }
    //    public virtual int CategoryId { get; set; }
    //    public virtual bool IsJson { get; set; }
    //    public virtual string Metadata { get; set; }
    //    public virtual DateTime Date { get; set; }
    //    public virtual DateTime TimeStamp { get; set; }
    //}

    //public class DataProviderMonitoringConfigurationModel : ReadModelEntity
    //{
    //    public DataProviderMonitoringConfigurationModel()
    //    {
    //    }

    //    public DataProviderMonitoringConfigurationModel(Guid id)
    //        : base(id)
    //    {

    //    }

    //    public virtual string Originator { get; set; }
    //    public virtual string OrignalMessageId { get; set; }
    //    public virtual Guid RequestAggregateId { get; set; }
    //    public virtual string Payload { get; set; }
    //    public virtual string Message { get; set; }
    //    public virtual int DataProviderId { get; set; }
    //    public virtual string DataProvider { get; set; }
    //    public virtual string Category { get; set; }
    //    public virtual int CategoryId { get; set; }
    //    public virtual bool IsJson { get; set; }
    //    public virtual string Metadata { get; set; }
    //    public virtual DateTime Date { get; set; }
    //    public virtual DateTime TimeStamp { get; set; }
    //}

    //public class DataProviderMonitoringSecurityModel : ReadModelEntity
    //{
    //    public DataProviderMonitoringSecurityModel()
    //    {
    //    }

    //    public DataProviderMonitoringSecurityModel(Guid id)
    //        : base(id)
    //    {

    //    }

    //    public virtual string Originator { get; set; }
    //    public virtual string OrignalMessageId { get; set; }
    //    public virtual Guid RequestAggregateId { get; set; }
    //    public virtual string Payload { get; set; }
    //    public virtual string Message { get; set; }
    //    public virtual int DataProviderId { get; set; }
    //    public virtual string DataProvider { get; set; }
    //    public virtual string Category { get; set; }
    //    public virtual int CategoryId { get; set; }
    //    public virtual bool IsJson { get; set; }
    //    public virtual string Metadata { get; set; }
    //    public virtual DateTime Date { get; set; }
    //    public virtual DateTime TimeStamp { get; set; }
    //}

    //public class DataProviderMonitoringAccountingModel : ReadModelEntity
    //{
    //    public DataProviderMonitoringAccountingModel()
    //    {
    //    }

    //    public DataProviderMonitoringAccountingModel(Guid id)
    //        : base(id)
    //    {

    //    }

    //    public virtual string Originator { get; set; }
    //    public virtual string OrignalMessageId { get; set; }
    //    public virtual Guid RequestAggregateId { get; set; }
    //    public virtual string Payload { get; set; }
    //    public virtual string Message { get; set; }
    //    public virtual int DataProviderId { get; set; }
    //    public virtual string DataProvider { get; set; }
    //    public virtual string Category { get; set; }
    //    public virtual int CategoryId { get; set; }
    //    public virtual bool IsJson { get; set; }
    //    public virtual string Metadata { get; set; }
    //    public virtual DateTime Date { get; set; }
    //    public virtual DateTime TimeStamp { get; set; }
    //}

    //public class DataProviderMonitoringTransformationModel : ReadModelEntity
    //{
    //    public DataProviderMonitoringTransformationModel()
    //    {
    //    }

    //    public DataProviderMonitoringTransformationModel(Guid id)
    //        : base(id)
    //    {

    //    }

    //    public virtual string Originator { get; set; }
    //    public virtual string OrignalMessageId { get; set; }
    //    public virtual Guid RequestAggregateId { get; set; }
    //    public virtual string Payload { get; set; }
    //    public virtual string Message { get; set; }
    //    public virtual int DataProviderId { get; set; }
    //    public virtual string DataProvider { get; set; }
    //    public virtual string Category { get; set; }
    //    public virtual int CategoryId { get; set; }
    //    public virtual bool IsJson { get; set; }
    //    public virtual string Metadata { get; set; }
    //    public virtual DateTime Date { get; set; }
    //    public virtual DateTime TimeStamp { get; set; }
    //}
}
