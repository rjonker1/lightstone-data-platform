using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Domain.Events;
using Lim.Domain.EventStore.Entities;
using Lim.Domain.Extensions;

namespace Lim.Domain.EventStore
{
    public class EventStore : IEventStore
    {
        private static readonly ILog Log = LogManager.GetLogger<EventStore>();
        private readonly IPublish _publisher;
        private readonly IEventStoreRepository _repository;

        private struct EventDescriptor
        {
            public EventDescriptor(LimEvent @event, long version, Guid aggregateId)
            {
                Event = @event;
                Version = version;
                Id = aggregateId;
            }

            public readonly LimEvent Event;
            public readonly Guid Id;
            public readonly long Version;
        }

        private readonly Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>();

        public EventStore(IPublish publisher, IEventStoreRepository repository)
        {
            _publisher = publisher;
            _repository = repository;
        }

        public void SaveEvents(Guid aggregateId, IEnumerable<LimEvent> events, long version)
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
                var descriptor = new EventDescriptor(@event, i, aggregateId);
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
                    AggregateId =  @event.Id,
                    EventType = @event.Event.EventType,
                    CorrelationId = @event.Event.CorrelationId,
                    EventTypeId = @event.Event.EventTypeId,
                    AggregateNew = @event.Event.AggregateNew,
                    Type = @event.Event.Type.FullName,
                    TypeName = @event.Event.TypeName,
                    Version = @event.Version,
                    UserName = @event.Event.User,
                    Payload = Encoding.UTF8.GetBytes(@event.Event.ObjectToJson())
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
