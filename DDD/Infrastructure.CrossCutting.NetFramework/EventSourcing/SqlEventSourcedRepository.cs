using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Serialization;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Utils;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.EventSourcing
{
    /// <summary>
    ///     This is an extremely basic implementation of the event store (straw man)
    ///     TODO: check for event versions before committing, nor is transactional with the event bus nor resilient to
    ///     connectivity errors or crashes.
    ///     TODO snapshots either for entities that implement <see cref="IMementoOriginator" />.
    /// </summary>
    /// <typeparam name="T">The entity type to persist.</typeparam>
    public class SqlEventSourcedRepository<T> : IEventSourcedRepository<T> where T : class, IEventSourced
    {
        // Could potentially use DataAnnotations to get a friendly/unique name in case of collisions between BCs.
        private static readonly string sourceType = typeof (T).Name;
        private readonly IEventBus eventBus;
        private readonly ITextSerializer serializer;
        private readonly Func<EventStoreDbContext> contextFactory;
        private readonly Func<Guid, IEnumerable<IVersionedEvent>, T> entityFactory;

        public SqlEventSourcedRepository(IEventBus eventBus, ITextSerializer serializer,
            Func<EventStoreDbContext> contextFactory)
        {
            this.eventBus = eventBus;
            this.serializer = serializer;
            this.contextFactory = contextFactory;

            // TODO: could be replaced with a compiled lambda
            ConstructorInfo constructor =
                typeof (T).GetConstructor(new[] {typeof (Guid), typeof (IEnumerable<IVersionedEvent>)});
            if (constructor == null)
            {
                throw new InvalidCastException(
                    "Type T must have a constructor with the following signature: .ctor(Guid, IEnumerable<IVersionedEvent>)");
            }
            entityFactory = (id, events) => (T) constructor.Invoke(new object[] {id, events});
        }

        public T Find(Guid id)
        {
            using (EventStoreDbContext context = contextFactory.Invoke())
            {
                CacheAnyEnumerableExtensions.IAnyEnumerable<IVersionedEvent> deserialized = context.Set<Event>()
                    .Where(x => x.AggregateId == id && x.AggregateType == sourceType)
                    .OrderBy(x => x.Version)
                    .AsEnumerable()
                    .Select(Deserialize)
                    .AsCachedAnyEnumerable();

                if (deserialized.Any())
                {
                    return entityFactory.Invoke(id, deserialized);
                }

                return null;
            }
        }

        public T Get(Guid id)
        {
            T entity = Find(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(id, sourceType);
            }

            return entity;
        }

        public void Save(T eventSourced, string correlationId)
        {
            // TODO: guarantee that only incremental versions of the event are stored
            IVersionedEvent[] events = eventSourced.Events.ToArray();
            using (EventStoreDbContext context = contextFactory.Invoke())
            {
                DbSet<Event> eventsSet = context.Set<Event>();
                foreach (IVersionedEvent e in events)
                {
                    eventsSet.Add(Serialize(e, correlationId));
                }

                context.SaveChanges();
            }

            // TODO: guarantee delivery or roll back, or have a way to resume after a system crash
            eventBus.Publish(events.Select(e => new Envelope<IEvent>(e) {CorrelationId = correlationId}));
        }

        private Event Serialize(IVersionedEvent e, string correlationId)
        {
            Event serialized;
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, e);
                serialized = new Event
                {
                    AggregateId = e.SourceId,
                    AggregateType = sourceType,
                    Version = e.Version,
                    Payload = writer.ToString(),
                    CorrelationId = correlationId
                };
            }
            return serialized;
        }

        private IVersionedEvent Deserialize(Event @event)
        {
            using (var reader = new StringReader(@event.Payload))
            {
                return (IVersionedEvent) serializer.Deserialize(reader);
            }
        }
    }
}