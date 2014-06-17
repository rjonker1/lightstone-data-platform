using System;
using DataPlatform.Shared.Public.Messaging;
using Monitoring.Sources.Lace;


namespace Monitoring
{
    public interface ITrackExternalSourceEventMessage :  IPublishableMessage
    {
        Guid Id { get; }

        Guid AggregateId { get; }
        LaceEventSource Source { get; }
        string Message { get; }
        DateTime EventDate { get; }
    }
}
