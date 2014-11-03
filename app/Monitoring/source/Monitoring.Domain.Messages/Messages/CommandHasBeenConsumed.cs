using System;

namespace Monitoring.Domain.Messages.Messages
{
    public class CommandHasBeenConsumed
    {
        public Guid AggregateId { get; set; }
        public Guid EventId { get; set; }
        public bool IsTrue { get; set; }

        public CommandHasBeenConsumed()
        {
            
        }
    }
}
