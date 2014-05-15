using System;
using DataPlatform.Shared.Public.Messaging;
using Lace.Shared.Enums;

namespace Lace.Events
{
    public interface ILaceEventMessage : IPublishableMessage
    {
        Guid Id { get; }

        Guid AggregateId { get; set; }
        EventSource Source { get; set; }
        string Message { get; set; }
        DateTime EventDate { get; }
    }
}
