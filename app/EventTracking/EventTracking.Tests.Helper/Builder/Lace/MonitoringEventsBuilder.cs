using System;
using System.Threading;
using System.Threading.Tasks;
using EventTracking.Tests.Helper.Fakes.Lace;
using Monitoring.Consumer.Lace.Consumers;

namespace EventTracking.Tests.Helper.Builder.Lace
{
    public class MonitoringEventsBuilder
    {
        private Guid _aggregateId;
        private ExternalSourceConsumer _consumer;

        public void ForExternalSourceEvents()
        {
            Task.Run(() => StartConsumingExternalSourceEventsAsync());
        }

        private void StartConsumingExternalSourceEventsAsync()
        {
            var running = true;
            _aggregateId = Guid.NewGuid();

            _consumer = FakeExternalSourceEvents.ReceiveRequestInLace(_aggregateId, _consumer);
            _consumer = FakeExternalSourceEvents.StartCallingIvid(_aggregateId, _consumer);

            Thread.Sleep(5000);

            _consumer = FakeExternalSourceEvents.EndCallingIvid(_aggregateId, _consumer);
            Thread.Sleep(1000);

            _consumer = FakeExternalSourceEvents.StartCallingIvidTileHolder(_aggregateId, _consumer);
            Thread.Sleep(5000);
            _consumer = FakeExternalSourceEvents.EndCallingIvidTitleHolder(_aggregateId, _consumer);

            Thread.Sleep(1000);

            _consumer = FakeExternalSourceEvents.StartCallingRgtVin(_aggregateId, _consumer);
            Thread.Sleep(5000);
            _consumer = FakeExternalSourceEvents.EndCallingRgtVin(_aggregateId, _consumer);

            Thread.Sleep(1000);

            _consumer = FakeExternalSourceEvents.StartCallingAudatex(_aggregateId, _consumer);
            Thread.Sleep(5000);
            _consumer = FakeExternalSourceEvents.EndCallingAudatex(_aggregateId, _consumer);

            Thread.Sleep(1000);

            _consumer = FakeExternalSourceEvents.ReturnResponseFromLace(_aggregateId, _consumer);

        }
    }
}
