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
        private ExternalSourceExecutedConsumer _externalSourceExecutedConsumer;

        public void ForExternalSourceEvents()
        {
            Task.Run(() => StartConsumingExternalSourceEventsAsync());
        }

        private void StartConsumingExternalSourceEventsAsync()
        {
            var running = true;
            _aggregateId = Guid.NewGuid();

            _consumer = FakeExternalSourceEvents.ReceiveRequestInLace(_aggregateId, _consumer);
            _externalSourceExecutedConsumer = FakeExternalSourceEvents.StartCallingIvid(_aggregateId, _externalSourceExecutedConsumer);

            Thread.Sleep(5000);

            _externalSourceExecutedConsumer = FakeExternalSourceEvents.EndCallingIvid(_aggregateId, _externalSourceExecutedConsumer);
            Thread.Sleep(1000);

            _externalSourceExecutedConsumer = FakeExternalSourceEvents.StartCallingIvidTileHolder(_aggregateId, _externalSourceExecutedConsumer);
            Thread.Sleep(5000);
            _externalSourceExecutedConsumer = FakeExternalSourceEvents.EndCallingIvidTitleHolder(_aggregateId, _externalSourceExecutedConsumer);

            Thread.Sleep(1000);

            _externalSourceExecutedConsumer = FakeExternalSourceEvents.StartCallingRgtVin(_aggregateId, _externalSourceExecutedConsumer);
            Thread.Sleep(5000);
            _externalSourceExecutedConsumer = FakeExternalSourceEvents.EndCallingRgtVin(_aggregateId, _externalSourceExecutedConsumer);

            Thread.Sleep(1000);

            _externalSourceExecutedConsumer = FakeExternalSourceEvents.StartCallingAudatex(_aggregateId, _externalSourceExecutedConsumer);
            Thread.Sleep(5000);
            _externalSourceExecutedConsumer = FakeExternalSourceEvents.EndCallingAudatex(_aggregateId, _externalSourceExecutedConsumer);

            Thread.Sleep(1000);

            _consumer = FakeExternalSourceEvents.ReturnResponseFromLace(_aggregateId, _consumer);

        }
    }
}
