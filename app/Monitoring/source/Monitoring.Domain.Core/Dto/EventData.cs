using System;

namespace Monitoring.Domain.Core.Dto
{
    public class EventData
    {
        public readonly byte[] Data;
        public readonly Guid EventId;
        public readonly bool IsJson;
        public readonly byte[] Metadata;
        public readonly string Type;

        public EventData()
        {
        }

        public EventData(Guid eventId, string type, bool isJson, byte[] data, byte[] metadata)
        {
            EventId = eventId;
            Type = type;
            IsJson = isJson;
            Data = data;
            Metadata = metadata;
        }
    }
}
