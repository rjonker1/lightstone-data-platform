﻿using System;

namespace Monitoring.Events.Lace
{
    public interface IEvent
    {
        Guid Id { get; }
        Guid AggregateId { get; }
        int SourceId { get; }
        string Message { get; }
        DateTime EventDate { get; }
    }
}
