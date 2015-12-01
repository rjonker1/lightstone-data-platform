using System;
using System.Collections.Generic;
using System.Linq;
using Toolbox.LightstoneAuto.Database.Domain.Base;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Repository
{
    public class EventStore : IEventStore
    {
        private readonly IEventPublisher _publisher;

        private struct EventDescriptor
        {
            public EventDescriptor(Guid id, Event @event, int version)
            {
                Event = @event;
                Version = version;
                Id = id;
            }

            public readonly Event Event;
            public readonly Guid Id;
            public readonly int Version;
        }

        private readonly Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>();

        public EventStore(IEventPublisher publisher)
        {
            _publisher = publisher;
        }

        public void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int version)
        {
            List<EventDescriptor> eventDescriptors;
            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                eventDescriptors = new List<EventDescriptor>();
                _current.Add(aggregateId, eventDescriptors);
            }
            else if(eventDescriptors[eventDescriptors.Count - 1].Version != version && version != -1)
            {
                throw new ConcurrencyException();
            }

            var i = version;
            foreach (var @event in events)
            {
                i++;
                @event.Version = i;
                eventDescriptors.Add(new EventDescriptor(aggregateId, @event, i));
                _publisher.Publish(@event);
            }
        }

        public List<Event> GetEventsForAggregate(Guid aggregateId)
        {
            List<EventDescriptor> eventDescriptors;
            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                throw new AggregateNotFoundException();
            }
            return eventDescriptors.Select(desc => desc.Event).ToList();
        }
    }

    public class AggregateNotFoundException : Exception
    {
    }

    public class ConcurrencyException : Exception
    {
    }
}
