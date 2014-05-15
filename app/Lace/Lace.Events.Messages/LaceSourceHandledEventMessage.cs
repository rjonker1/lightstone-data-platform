using System;
using Lace.Shared.Enums;

namespace Lace.Events.Messages
{
    public class LaceSourceHandledEventMessage : ILaceEventMessage
    {
        public Guid Id
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public Guid AggregateId { get; set; }
        public EventSource Source { get; set; }
        public string Message { get; set; }

        public DateTime EventDate
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
