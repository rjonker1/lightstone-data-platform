using System;
using Monitoring.Sources;

namespace Monitoring.Modules.Lace.AggregateEvents
{
    public class ExternalSourceFailedEvent
    {

        public ExternalSourceFailedEvent(Guid id, FromSource source, string message, DateTime eventDate)
        {
            Id = id;
            Source = source;
            Message = message;
            EventDate = eventDate;
        }

        public Guid Id { get; private set; }
        public FromSource Source { get; private set; }
        public string Message { get; private set; }
        public DateTime EventDate { get; private set; }
    }
}
