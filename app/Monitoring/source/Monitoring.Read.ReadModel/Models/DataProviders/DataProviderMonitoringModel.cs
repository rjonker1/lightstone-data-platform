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
        public virtual Guid EventId { get; set; }
        public virtual string Payload { get; set; }
        public virtual int DataProviderId { get; set; }
        public virtual bool IsJson { get; set; }
        public virtual string MetaData { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
