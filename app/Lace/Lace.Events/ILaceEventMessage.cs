using System;
using DataPlatform.Shared.Public.Messaging;
using Lace.Shared.Enums;

namespace Lace.Events
{
    public interface ILaceEventMessage : IPublishableMessage
    {
        Guid Id { get; }

        Guid AggregateId { get; }
        EventSource Source { get;  }
        string Message { get;  }
        DateTime EventDate { get; }
    }
}
