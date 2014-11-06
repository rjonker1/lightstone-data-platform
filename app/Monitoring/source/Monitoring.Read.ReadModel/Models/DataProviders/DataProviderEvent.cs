using System;
namespace Monitoring.Read.ReadModel.Models.DataProviders
{
    public class DataProviderEvent : ReadModelEntity
    {
        public DataProviderEvent()
        {
        }

        public DataProviderEvent(Guid id) : base(id)
        {
            
        }

        public DateTime TimeStamp { get; set; }
        public int Source { get; set; }
        public string Payload { get; set; }
    }
}
