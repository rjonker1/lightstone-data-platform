﻿using System;

namespace Monitoring.Modules.Lace.AggregateEvents
{
    public class AggregateExternalSourceFailedEvent : AggregateExternalSourceBaseEvent
    {
        public AggregateExternalSourceFailedEvent(Guid id, Guid aggregateId, string source, string message, DateTime eventDate)
        {
            Id = id;
            AggregateId = aggregateId;
            Source = source;
            Message = message;
            EventDate = eventDate;
        }
    }
}
