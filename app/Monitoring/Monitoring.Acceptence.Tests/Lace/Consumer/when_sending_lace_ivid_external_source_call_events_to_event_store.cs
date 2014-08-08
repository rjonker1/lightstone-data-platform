using System;
using System.Threading;
using EventTracking.Domain.Persistence;
using EventTracking.Domain.Persistence.EventStore;
using Monitoring.Acceptance.Tests.Fakes;
using Monitoring.Consumer.Lace.Consumers;
using Monitoring.Test.Helper.Fakes;
using Xunit.Extensions;

namespace Monitoring.Acceptance.Tests.Lace.Consumer
{
    public class when_sending_lace_ivid_external_source_call_events_to_event_store : Specification
    {

        private readonly Guid _aggregateId;
        private ExternalSourceConsumer _consumer;
        private ExternalSourceExecutedConsumer _externalSourceExecutedConsumer;
        private readonly IPersistAnEvent _persistEvent;

        public when_sending_lace_ivid_external_source_call_events_to_event_store()
        {
            _aggregateId = Guid.NewGuid();
            _persistEvent = new PersistEvent(); // new PersistEvent(); //TODO: Add FakePersistEvent
        }

        public override void Observe()
        {
            
        }

        [Observation]
        public void monitoring_lace_external_source_start_and_end_sources_call_consumed_must_be_true()
        {

            _consumer = FakeLaceExternalSourceEvents.ReceiveRequestInLace(_aggregateId, _consumer, _persistEvent);
            _consumer.HasBeenConsumed.ShouldBeTrue();

            _externalSourceExecutedConsumer = FakeLaceExternalSourceEvents.StartCallingIvid(_aggregateId, _externalSourceExecutedConsumer, _persistEvent);
            _externalSourceExecutedConsumer.HasBeenConsumed.ShouldBeTrue();

            Thread.Sleep(5000);

            _externalSourceExecutedConsumer = FakeLaceExternalSourceEvents.EndCallingIvid(_aggregateId, _externalSourceExecutedConsumer, _persistEvent);
            _externalSourceExecutedConsumer.HasBeenConsumed.ShouldBeTrue();

            Thread.Sleep(1000);

            _externalSourceExecutedConsumer = FakeLaceExternalSourceEvents.StartCallingIvidTileHolder(_aggregateId, _externalSourceExecutedConsumer, _persistEvent);
            _externalSourceExecutedConsumer.HasBeenConsumed.ShouldBeTrue();

            Thread.Sleep(5000);

            _externalSourceExecutedConsumer = FakeLaceExternalSourceEvents.EndCallingIvidTitleHolder(_aggregateId, _externalSourceExecutedConsumer, _persistEvent);
            _externalSourceExecutedConsumer.HasBeenConsumed.ShouldBeTrue();

            Thread.Sleep(1000);


            _externalSourceExecutedConsumer = FakeLaceExternalSourceEvents.StartCallingRgtVin(_aggregateId, _externalSourceExecutedConsumer, _persistEvent);
            _externalSourceExecutedConsumer.HasBeenConsumed.ShouldBeTrue();

            Thread.Sleep(5000);

            _externalSourceExecutedConsumer = FakeLaceExternalSourceEvents.EndCallingRgtVin(_aggregateId, _externalSourceExecutedConsumer, _persistEvent);
            _externalSourceExecutedConsumer.HasBeenConsumed.ShouldBeTrue();

            Thread.Sleep(1000);


            _externalSourceExecutedConsumer = FakeLaceExternalSourceEvents.StartCallingAudatex(_aggregateId, _externalSourceExecutedConsumer, _persistEvent);
            _externalSourceExecutedConsumer.HasBeenConsumed.ShouldBeTrue();

            Thread.Sleep(5000);

            _externalSourceExecutedConsumer = FakeLaceExternalSourceEvents.EndCallingAudatex(_aggregateId, _externalSourceExecutedConsumer, _persistEvent);
            _externalSourceExecutedConsumer.HasBeenConsumed.ShouldBeTrue();
            
            Thread.Sleep(1000);

            _consumer = FakeLaceExternalSourceEvents.ReturnResponseFromLace(_aggregateId, _consumer, _persistEvent);
            _consumer.HasBeenConsumed.ShouldBeTrue();
     
        }

       

    }
}
