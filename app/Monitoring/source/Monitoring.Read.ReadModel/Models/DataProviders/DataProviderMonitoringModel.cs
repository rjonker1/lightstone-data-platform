using System;
namespace Monitoring.Read.ReadModel.Models.DataProviders
{
    public class DataProviderMonitoringModel : ReadModelEntity
    {
        public DataProviderMonitoringModel()
        {
        }

        public DataProviderMonitoringModel(Guid id) : base(id)
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
}
