using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace Lace.Shared.Monitoring.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class CommandDto
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public MonitoringSource Source { get; private set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public DateTime DateUtc { get; private set; }

        [DataMember]
        public int Order { get; private set; }

        [DataMember]
        public int SubOrder { get; private set; }


        public CommandDto()
        {

        }

        public CommandDto(Guid id, MonitoringSource source, string payload, DateTime date, int order, int subOrder)
        {
            Id = id;
            Source = source;
            Payload = payload;
            DateUtc = date;
            Order = order;
            SubOrder = subOrder;
        }
    }
}
