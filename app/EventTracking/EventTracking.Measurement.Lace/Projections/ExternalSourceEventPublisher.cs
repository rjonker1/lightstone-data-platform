using System;
using EasyNetQ;
using EventStore.ClientAPI;
using EventTracking.Domain.Core;
using EventTracking.Measurement.Lace.Events;

namespace EventTracking.Measurement.Lace.Projections
{
    public class ExternalSourceEventPublisher
    {
        private const string CheckpointStream = "$publisher-ExternalSourceEventPublisher-checkpoint";
        private const string EventStream = "ExternalSourceEvents";

        private readonly IEventStoreConnection _eventStoreConnection;
        private readonly IBus _bus;

        private bool _running;

        public ExternalSourceEventPublisher(IEventStoreConnection eventStoreConnection, IBus bus)
        {
            _eventStoreConnection = eventStoreConnection;
            _bus = bus;
        }

        public void Start()
        {
            if (_running) return;

            _running = true;

            Connect();
        }

        public void Stop()
        {
            if (!_running) return;

            _running = false;
        }

        private void Connect()
        {
            var position = GetLastCheckpoint(CheckpointStream);

            _eventStoreConnection.SubscribeToStreamFrom(EventStream, position, true, ProcessEvent,
                userCredentials: EventStoreCredentials.Default, subscriptionDropped: TryToReconnect);
        }

        private void TryToReconnect(EventStoreCatchUpSubscription catchUpSubscription, SubscriptionDropReason reason,
            Exception exception)
        {
            Console.WriteLine("Projection subscription dropped because of {0} . Exception: {1}", reason, exception);

            Connect();
        }


        private void ProcessEvent(EventStoreCatchUpSubscription subscribtion, ResolvedEvent resolvedEvent)
        {
            var sourceEvent = resolvedEvent.ParseJson<ExternalSourceEventRead>();

            Console.WriteLine(sourceEvent);

            //Publish(sourceEvent);

            StoreCheckpoint(resolvedEvent);
        }

        private void Publish(ExternalSourceEventRead sourceEvent)
        {
            _bus.Publish(sourceEvent);
        }

        private void StoreCheckpoint(ResolvedEvent resolvedEvent)
        {
            var eventNumber = resolvedEvent.Event.EventNumber;
            var checkpoint = new ExternalSourceEvenPublisherCheckpoint(eventNumber)
                .AsJsonEvent();

            SetCheckpointStreamMaxCount(eventNumber);

            _eventStoreConnection.AppendToStream(CheckpointStream, ExpectedVersion.Any, EventStoreCredentials.Default,
                checkpoint);
        }

        private void SetCheckpointStreamMaxCount(int eventNumber)
        {
            if (eventNumber != 0) return;

            var metadata = StreamMetadata.Build().SetMaxCount(1);

            _eventStoreConnection.SetStreamMetadata(CheckpointStream, ExpectedVersion.Any, metadata,
                EventStoreCredentials.Default);
        }

        private int? GetLastCheckpoint(string stateStream)
        {
            var state = _eventStoreConnection.GetLastEvent<ExternalSourceEvenPublisherCheckpoint>(stateStream);
            return state != null ? state.LastProcessedEvent : (int?) null;
        }
    }
}
