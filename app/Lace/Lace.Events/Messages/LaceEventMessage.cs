using System;
using DataPlatform.Shared.Public.Messaging;
using Lace.Shared.Enums;

namespace Lace.Events.Messages
{
    public class LaceEventMessage : IPublishableMessage
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
