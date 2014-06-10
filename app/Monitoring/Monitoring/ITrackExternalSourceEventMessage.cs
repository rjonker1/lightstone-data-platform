using System;
using DataPlatform.Shared.Public.Messaging;
using Monitoring.Sources;


namespace Monitoring
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
