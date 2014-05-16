using System;
using DataPlatform.Shared.Public.Messaging;
using EventTracking.Sources;

namespace EventTracking
{
    public interface ITrackExternalSourceEventMessage :  IPublishableMessage
    {
        Guid Id { get; }

        Guid AggregateId { get; }
        FromSource Source { get; }
        string Message { get; }
        DateTime EventDate { get; }
    }
}
