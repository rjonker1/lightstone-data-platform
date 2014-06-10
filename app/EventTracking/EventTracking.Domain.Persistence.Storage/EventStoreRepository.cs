﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore.ClientAPI;
using EventTracking.Domain.Persistence.Storage.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EventTracking.Domain.Persistence.Storage
{
    public class EventStoreRepository : IRepository, IDisposable
    {
        private readonly Func<Type, Guid, string> _aggregateIdToStreamName;
        private readonly IEventStoreConnection _eventStoreConnection;
        private static readonly JsonSerializerSettings SerializerSettings;

        private const string CommitIdHeader = "CommitId";
        private const string EventClrTypeHeader = "EventClrTypeName";
        private const string AggregateClrTypeHeader = "AggregateClrTypeName";

        private const int WritePageSize = 500;
        private const int ReadPageSize = 500;

        static EventStoreRepository()
        {
            SerializerSettings = new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.None};
        }

        //public EventStoreRepository(IEventStoreConnection eventStoreConnection)
        //    : this(
        //        eventStoreConnection,
        //        (t, g) => string.Format("{0}-{1}", char.ToLower(t.Name[0]) + t.Name.Substring(1), g.ToString("N")))
        //{
        //}

        public EventStoreRepository(IEventStoreConnection eventStoreConnection)
            : this(
                eventStoreConnection,
                (t, g) => string.Format("{0}", char.ToLower(t.Name[0]) + t.Name.Substring(1)))
        {
        }

        public EventStoreRepository(IEventStoreConnection eventStoreConnection,
            Func<Type, Guid, string> aggregateIdToStreamName)
        {
            _eventStoreConnection = eventStoreConnection;
            _aggregateIdToStreamName = aggregateIdToStreamName;
        }
        

        public TAggregate GetById<TAggregate>(Guid id) where TAggregate : class, IAggregate
        {
            return GetById<TAggregate>(id, int.MaxValue);
        }



        public TAggregate GetById<TAggregate>(Guid id, int version) where TAggregate : class, IAggregate
        {
            if (version <= 0)
                throw new InvalidOperationException("Cannot get version <= 0");

            var streamName = _aggregateIdToStreamName(typeof(TAggregate), id);
            var aggregate = ConstructAggregate<TAggregate>();

            var sliceStart = 0;

            StreamEventsSlice currentSlice;

            do
            {
                var sliceCount = sliceStart + ReadPageSize <= version
                                    ? ReadPageSize
                                    : (version - sliceStart) + 1;

                currentSlice = _eventStoreConnection.ReadStreamEventsForward(streamName, sliceStart, sliceCount, false);

                if (currentSlice.Status == SliceReadStatus.StreamNotFound)
                    throw new AggregateNotFoundException(id, typeof(TAggregate));

                if (currentSlice.Status == SliceReadStatus.StreamDeleted)
                    throw new AggregateDeletedException(id, typeof(TAggregate));

                sliceStart = currentSlice.NextEventNumber;

                foreach (var evnt in currentSlice.Events)
                    aggregate.ApplyEvent(DeserializeEvent(evnt.OriginalEvent.Metadata, evnt.OriginalEvent.Data));
            } while (version >= currentSlice.NextEventNumber && !currentSlice.IsEndOfStream);


            if (aggregate.Version != version && version < Int32.MaxValue)
                throw new AggregateVersionException(id, typeof(TAggregate), aggregate.Version, version);

            return aggregate;
        }



        public TEvent[] GetStreams<TEvent>(string streamName, int pageSize) where TEvent : class
        {
            var result = new List<ResolvedEvent>();
            var coursor = StreamPosition.Start;
            StreamEventsSlice events = null;
            pageSize = pageSize == 0 ? 500 : pageSize;
            do
            {
                events = _eventStoreConnection.ReadStreamEventsForward(streamName, coursor, pageSize, false);
                result.AddRange(events.Events);
                coursor = events.NextEventNumber;

            } while (!events.IsEndOfStream);

            var aggreates = new List<TEvent>();

            foreach (var resolvedEvent in result)
            {
                //var aggregate = ConstructAggregate<TEvent>();
                //aggregate.ApplyEvent(DeserializeEvent(resolvedEvent.OriginalEvent.Metadata,
                //    resolvedEvent.OriginalEvent.Data));

                var eventDetails = (TEvent)DeserializeEvent(resolvedEvent.OriginalEvent.Metadata, resolvedEvent.OriginalEvent.Data);

                aggreates.Add(eventDetails);
            }

            return aggreates.ToArray();
        }

        //public IEnumerable<ResolvedEvent> ReadAllEventsInStream(string streamName, IEventStoreConnection connection, int pageSize = 500)
        //{
        //    var result = new List<ResolvedEvent>();
        //    var coursor = StreamPosition.Start;
        //    StreamEventsSlice events = null;
        //    do
        //    {
        //        events = connection.ReadStreamEventsForward(streamName, coursor, pageSize, false);
        //        result.AddRange(events.Events);
        //        coursor = events.NextEventNumber;

        //    } while (events != null && !events.IsEndOfStream);

        //    return result;
        //}


        private static TAggregate ConstructAggregate<TAggregate>()
        {
            return (TAggregate)Activator.CreateInstance(typeof(TAggregate), true);
        }

        private static object DeserializeEvent(byte[] metadata, byte[] data)
        {
            var eventClrTypeName = JObject.Parse(Encoding.UTF8.GetString(metadata)).Property(EventClrTypeHeader).Value;
            return JsonConvert.DeserializeObject(Encoding.UTF8.GetString(data), Type.GetType((string)eventClrTypeName));
        }

        private static object DeserializeEventData(byte[] data)
        {
            return JsonConvert.DeserializeObject(Encoding.UTF8.GetString(data));
        }

        public void Save(IAggregate aggregate, Guid commitId, Action<IDictionary<string, object>> updateHeaders)
        {
            var commitHeaders = new Dictionary<string, object>
            {
                {CommitIdHeader, commitId},
                {AggregateClrTypeHeader, aggregate.GetType().AssemblyQualifiedName}
            };
            updateHeaders(commitHeaders);

            var streamName = _aggregateIdToStreamName(aggregate.GetType(), aggregate.Id);
            var newEvents = aggregate.GetUncommittedEvents().Cast<object>().ToList();
            var originalVersion = aggregate.Version - newEvents.Count;
            //var expectedVersion = originalVersion == 0 ? ExpectedVersion.NoStream : originalVersion;
            //var expectedVersion = originalVersion == 0 ? ExpectedVersion.NoStream : originalVersion - 1;
            var expectedVersion = originalVersion == 0 ? CheckForExistingStreamVersion(streamName) : originalVersion - 1;

            var eventsToSave = newEvents.Select(e => ToEventData(Guid.NewGuid(), e, commitHeaders)).ToList();

            if (eventsToSave.Count < WritePageSize)
            {
                _eventStoreConnection.AppendToStream(streamName, expectedVersion, eventsToSave);
            }
            else
            {
                var transaction = _eventStoreConnection.StartTransaction(streamName, expectedVersion);

                var position = 0;
                while (position < eventsToSave.Count)
                {
                    var pageEvents = eventsToSave.Skip(position).Take(WritePageSize);
                    transaction.Write(pageEvents);
                    position += WritePageSize;
                }

                transaction.Commit();
            }

            aggregate.ClearUncommittedEvents();
        }

        private int CheckForExistingStreamVersion(string streamName)
        {
            var read = _eventStoreConnection.ReadStreamEventsBackward(streamName, StreamPosition.End, 1, false);

            return read.Events.Count() > 0 ? read.LastEventNumber : ExpectedVersion.NoStream;
        }

        private static EventData ToEventData(Guid eventId, object evnt, IDictionary<string, object> headers)
        {
            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(evnt, SerializerSettings));

            var eventHeaders = new Dictionary<string, object>(headers)
            {
                {
                    EventClrTypeHeader, evnt.GetType().AssemblyQualifiedName
                }
            };
            var metadata = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(eventHeaders, SerializerSettings));
            var typeName = evnt.GetType().Name;

            return new EventData(eventId, typeName, true, data, metadata);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            _eventStoreConnection.Close();
        }


        
    }
}
