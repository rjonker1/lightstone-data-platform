using System;
using System.Threading;
using System.Threading.Tasks;
using EventTracking.Domain.Persistence;
using EventTracking.Domain.Persistence.EventStore;
using EventTracking.Tests.Helper.Fakes.Lace;
using EventTracking.Tests.Helper.Fakes.Persistence;
using Monitoring.Consumer.Lace.Consumers;

namespace EventTracking.Tests.Helper.Builder.Lace
{
    public class MonitoringEventsBuilder
    {
        private Guid _aggregateId;
        private ExternalSourceConsumer _consumer;
        private ExternalSourceExecutedConsumer _externalSourceExecutedConsumer;
        private IPersistAnEvent _persistAnEvent;

        public MonitoringEventsBuilder(IPersistAnEvent persistAnEvent)
        {
            _persistAnEvent = persistAnEvent;
        }

        public MonitoringEventsBuilder()
        {
            
        }

        public MonitoringEventsBuilder PersistToEventStore()
        {
            _persistAnEvent = new PersistEvent();
            return this;
        }

        public MonitoringEventsBuilder PersistToFakeEventStore()
        {
            _persistAnEvent = new FakePersistEvent();
            return this;
        }

        public void ForExternalSourceEvents()
        {
            Task.Run(() => StartConsumingExternalSourceEventsAsync());
        }

        public void ForStartingAndEndingCallToIvid()
        {
            _aggregateId = Guid.NewGuid();

            _consumer = FakeExternalSourceEvents.ReceiveRequestInLace(_aggregateId, _consumer, _persistAnEvent);
            _externalSourceExecutedConsumer = FakeExternalSourceEvents.StartCallingIvid(_aggregateId,
                _externalSourceExecutedConsumer, _persistAnEvent);

            Thread.Sleep(5000);

            _externalSourceExecutedConsumer = FakeExternalSourceEvents.EndCallingIvid(_aggregateId,
                _externalSourceExecutedConsumer, _persistAnEvent);
            Thread.Sleep(1000);
        }

        private void StartConsumingExternalSourceEventsAsync()
        {
            _aggregateId = Guid.NewGuid();

            _consumer = FakeExternalSourceEvents.ReceiveRequestInLace(_aggregateId, _consumer, _persistAnEvent);
            _externalSourceExecutedConsumer = FakeExternalSourceEvents.StartCallingIvid(_aggregateId, _externalSourceExecutedConsumer, _persistAnEvent);

            Thread.Sleep(5000);

            _externalSourceExecutedConsumer = FakeExternalSourceEvents.EndCallingIvid(_aggregateId, _externalSourceExecutedConsumer, _persistAnEvent);
            Thread.Sleep(1000);

            _externalSourceExecutedConsumer = FakeExternalSourceEvents.StartCallingIvidTileHolder(_aggregateId, _externalSourceExecutedConsumer, _persistAnEvent);
            Thread.Sleep(5000);
            _externalSourceExecutedConsumer = FakeExternalSourceEvents.EndCallingIvidTitleHolder(_aggregateId, _externalSourceExecutedConsumer, _persistAnEvent);

            Thread.Sleep(1000);

            _externalSourceExecutedConsumer = FakeExternalSourceEvents.StartCallingRgtVin(_aggregateId, _externalSourceExecutedConsumer, _persistAnEvent);
            Thread.Sleep(5000);
            _externalSourceExecutedConsumer = FakeExternalSourceEvents.EndCallingRgtVin(_aggregateId, _externalSourceExecutedConsumer, _persistAnEvent);

            Thread.Sleep(1000);

            _externalSourceExecutedConsumer = FakeExternalSourceEvents.StartCallingAudatex(_aggregateId, _externalSourceExecutedConsumer, _persistAnEvent);
            Thread.Sleep(5000);
            _externalSourceExecutedConsumer = FakeExternalSourceEvents.EndCallingAudatex(_aggregateId, _externalSourceExecutedConsumer, _persistAnEvent);

            Thread.Sleep(1000);

            _consumer = FakeExternalSourceEvents.ReturnResponseFromLace(_aggregateId, _consumer, _persistAnEvent);

        }
    }
}
