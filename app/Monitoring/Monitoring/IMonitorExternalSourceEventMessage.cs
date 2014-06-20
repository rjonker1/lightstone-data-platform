using System;
using DataPlatform.Shared.Messaging;
using Monitoring.Sources.Lace;


namespace Monitoring
{
    public interface IMonitorExternalSourceEventMessage :  IPublishableMessage
    {
        Guid Id { get; }

        Guid AggregateId { get; }
        LaceEventSource Source { get; }
        string Message { get; }
        DateTime EventDate { get; }
        string Category { get; }
    }
}
