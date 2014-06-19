using System;
using System.Collections;

namespace EventTracking.Domain
{
    public interface IAggregate
    {
        Guid Id { get; }
        int Version { get; }
        string Category { get; }

        void ApplyEvent(object @event);
        ICollection GetUncommittedEvents();
        void ClearUncommittedEvents();

        IMemento GetSnapshot();
    }
}
