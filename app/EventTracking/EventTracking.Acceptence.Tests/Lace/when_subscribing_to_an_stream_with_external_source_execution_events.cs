using System;
using System.Linq;
using EventStore.ClientAPI;
using EventTracking.Domain.Core;
using EventTracking.Measurement;
using EventTracking.Measurement.Dto;
using EventTracking.Measurement.Lace.Events;
using EventTracking.Measurement.Repository;
using EventTracking.Measurement.Streams;
using EventTracking.Tests.Helper.Builder.Lace;
using Xunit.Extensions;

namespace EventTracking.Acceptence.Tests.Lace
{
    public class when_reading_events_from_lace_external_source_projections : Specification
    {
        //private readonly string _checkpointStream =
        //    ExternalSourceEventStreams.PublisherExternalSourceExecutionEventPublisherCheckpoint();

        //private readonly string _eventStream = ExternalSourceEventStreams.ExternalSourceExecutionEvents();

        //private readonly IEventStoreConnection _eventStoreConnection;

        //private static readonly IRepository<ExternalSourceExecutionResultDto> Repository =
        //    new FakeSourceExecutionRepository();

        //public when_reading_events_from_lace_external_source_projections()
        //{
        //    _eventStoreConnection = ConnectionFactory.Default();
        //}


        public override void Observe()
        {
            //new MonitoringEventsBuilder().ForExternalSourceEvents();

            //var position = GetLastCheckpoint(_checkpointStream);

            //_eventStoreConnection.SubscribeToStreamFrom(_eventStream, position, true, ProcessEvent,
            //    userCredentials: EventStoreCredentials.Default, subscriptionDropped: TryToReconnect);
        }

        //private int? GetLastCheckpoint(string stateStream)
        //{
        //    var state = _eventStoreConnection.GetLastEvent<ExternalSourceEvenPublisherCheckpoint>(stateStream);
        //    return state != null ? state.LastProcessedEvent : (int?)null;
        //}
    }
} 
