using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Domain.EventStore.Entities;

namespace Lim.Domain.EventStore
{
    public class EventStore : IEventStore
    {
        private static readonly ILog Log = LogManager.GetLogger<EventStore>();
        private readonly IPublish _publisher;
        private readonly IEventStoreRepository _repository;

        private struct EventDescriptor
        {
            public EventDescriptor(Guid id, LimEvent @event, int version)
            {
                Event = @event;
                Version = version;
                Id = id;
            }

            public readonly LimEvent Event;
            public readonly Guid Id;
            public readonly int Version;
        }

        private readonly Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>();

        public EventStore(IPublish publisher, IEventStoreRepository repository)
        {
            _publisher = publisher;
            _repository = repository;
        }

        public void SaveEvents(Guid aggregateId, IEnumerable<LimEvent> events, int version)
        {
            List<EventDescriptor> eventDescriptors;
            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                eventDescriptors = new List<EventDescriptor>();
                _current.Add(aggregateId, eventDescriptors);
            }
            else if (eventDescriptors[eventDescriptors.Count - 1].Version != version && version != -1)
            {
                throw new ConcurrencyException();
            }

            var i = version;
            foreach (var @event in events)
            {
                i++;
                @event.Version = i;
                var descriptor = new EventDescriptor(aggregateId, @event, i);
                eventDescriptors.Add(descriptor);
                Save(descriptor);

                _publisher.Publish(@event);
            }
        }

        public List<LimEvent> GetEventsForAggregate(Guid aggregateId)
        {
            List<EventDescriptor> eventDescriptors;
            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                throw new AggregateNotFoundException();
            }
            return eventDescriptors.Select(desc => desc.Event).ToList();
        }

        private void Save(EventDescriptor @event)
        {
            try
            {
                var command = new EventCommand
                {
                    Id = Guid.NewGuid(),
                    EventType = @event.Event.EventType,
                    CorrelationId = @event.Id,
                    EventTypeId = @event.Event.EventTypeId,
                    Payload = @event.Event.Payload,
                    AggregateNew = @event.Event.AggregateNew,
                    Type = @event.Event.Type,
                    TypeName = @event.Event.TypeName,
                    Version = @event.Version,
                    User = @event.Event.User
                };

                _repository.Save(command);
            }
            catch (Exception ex)
            {
               Log.ErrorFormat("Could not save event because of {0}", ex, ex.Message);
            }
        }
    }

    public class AggregateNotFoundException : Exception
    {
    }

    public class ConcurrencyException : Exception
    {
    }
}
