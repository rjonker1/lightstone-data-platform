using System;
namespace Monitoring.Read.ReadModel.Models
{
    public class MonitoringStorageModel : ReadModelEntity
    {
        public MonitoringStorageModel()
        {
        }

        public MonitoringStorageModel(Guid id)
            : base(id)
        {

        }

        //public virtual string Originator { get; set; }
        //public virtual string OrignalMessageId { get; set; }
        public virtual byte[] Payload { get; set; }
        public virtual int Source { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime TimeStamp { get; set; }
    }
}
