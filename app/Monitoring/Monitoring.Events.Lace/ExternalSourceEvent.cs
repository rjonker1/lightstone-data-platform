﻿using System;
namespace Monitoring.Events.Lace
{
    public class ExternalSourceEvent : ExternalSourceBaseEvent
    {
        public ExternalSourceEvent(Guid id, Guid aggregateId, string source, string message, DateTime eventDate)
        {
            Id = id;
            AggregateId = aggregateId;
            Source = source;
            Message = message;
            EventDate = eventDate;
        }
    }
}